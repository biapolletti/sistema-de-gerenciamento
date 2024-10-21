using FastReport;
using FastReport.Data;
using FastReport.Export.PdfSimple;
using FastReport.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Pim_Web.Models;
using Pim_Web.Services;
using System.Configuration;
using System.Data;
using System.Drawing;

namespace Pim_Web.Controllers
{
    [Authorize]
    public class VendasController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly ApplicationDbContext _dataService;
        private readonly IWebHostEnvironment environment;
        private readonly IWebHostEnvironment _webHostEnv;

        public VendasController(ApplicationDbContext context, IWebHostEnvironment environment, IWebHostEnvironment webHostEnv, ApplicationDbContext dataService)
        {
            this.context = context;
            this.environment = environment;
            _webHostEnv = webHostEnv;
            _dataService = dataService;
        }

        public IActionResult Index()
        {
            var vendas = context.Vendas.ToList();
            return View(vendas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(VendasDto vendasDto)
        {
            if (!ModelState.IsValid)
            {
                return View(vendasDto);
            }

            Vendas vendas = new Vendas()
            {
                DataVe = vendasDto.DataVe,
                DataEn = vendasDto.DataEn,
                Valor = vendasDto.Valor,
                QuantidadeItens = vendasDto.QuantidadeItens,
                Vendedor = vendasDto.Vendedor,
            };

            context.Vendas.Add(vendas);
            context.SaveChanges();

            return RedirectToAction("Index", "Vendas");
        }

        public IActionResult Edit(int id)
        {
            var vendas = context.Vendas.Find(id);

            if (vendas == null)
            {
                return RedirectToAction("Index", "Vendas");
            }

            var vendasDto = new VendasDto()
            {
                DataVe = vendas.DataVe,
                DataEn = vendas.DataEn,
                Valor = vendas.Valor,
                QuantidadeItens = vendas.QuantidadeItens,
                Vendedor = vendas.Vendedor,
            };

            return View(vendasDto);
        }

        [HttpPost]
        public IActionResult Edit(int id, VendasDto vendasDto)
        {
            var vendas = context.Vendas.Find(id);

            if (vendas == null)
            {
                return RedirectToAction("Index", "Vendas");
            }

            if (!ModelState.IsValid)
            {
                return View(vendasDto);
            }

            vendas.DataVe = vendasDto.DataVe;
            vendas.DataEn = vendasDto.DataEn;
            vendas.Valor = vendasDto.Valor;
            vendas.QuantidadeItens = vendasDto.QuantidadeItens;
            vendas.Vendedor = vendasDto.Vendedor;

            context.SaveChanges();
            return RedirectToAction("Index", "Vendas");
        }

        public IActionResult Delete(int id)
        {
            var vendas = context.Vendas.Find(id);

            if (vendas == null)
            {
                return RedirectToAction("Index", "Vendas");
            }

            context.Vendas.Remove(vendas);
            context.SaveChanges(true);
            return RedirectToAction("Index", "Vendas");
        }

        [Route("VendasPdf")]
        public IActionResult VendasPdf()
        {
            var webReport = new WebReport();

            var mssqlDataConnection = new MsSqlDataConnection();
            webReport.Report.Dictionary.Connections.Add(mssqlDataConnection);
            webReport.Report.Load(Path.Combine(_webHostEnv.ContentRootPath, "wwwroot/reports", "RelatorioVendas.frx"));

            var vendas = HelperFastReport.GetTable(_dataService.Vendas, "Vendas");

            webReport.Report.RegisterData(vendas, "Vendas");

            webReport.Report.Prepare();

            Stream stream = new MemoryStream();
            webReport.Report.Export(new PDFSimpleExport(), stream);
            stream.Position = 0;

            return File(stream, "application/zip", "RelatorioVendas.pdf");
        }
    }
}
