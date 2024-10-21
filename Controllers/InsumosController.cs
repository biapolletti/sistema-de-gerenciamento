using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pim_Web.Models;
using Pim_Web.Services;

namespace Pim_Web.Controllers
{
    [Authorize]
    public class InsumosController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment environment;

        public InsumosController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }

        public IActionResult Index()
        {
            var insumos = context.Insumos.ToList();
            return View(insumos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(InsumosDto insumosDto)
        {
            if (!ModelState.IsValid)
            {
                return View(insumosDto);
            }

            Insumos insumos = new Insumos()
            {
                Nome = insumosDto.Nome,
                Fornecedor = insumosDto.Fornecedor,
                Tipo = insumosDto.Tipo,
                Quantidade = insumosDto.Quantidade,
                ValorUni = insumosDto.ValorUni,
                DataVal = insumosDto.DataVal,
            };

            context.Insumos.Add(insumos);
            context.SaveChanges();

            return RedirectToAction("Index", "Insumos");
        }

        public IActionResult Edit(int id)
        {
            var insumos = context.Insumos.Find(id);

            if (insumos == null)
            {
                return RedirectToAction("Index", "Insumos");
            }

            var insumosDto = new InsumosDto()
            {
                Nome = insumos.Nome,
                Fornecedor = insumos.Fornecedor,
                Tipo = insumos.Tipo,
                Quantidade = insumos.Quantidade,
                ValorUni = insumos.ValorUni,
                DataVal = insumos.DataVal,
            };

            return View(insumosDto);
        }

        [HttpPost]
        public IActionResult Edit(int id, InsumosDto insumosDto)
        {
            var insumos = context.Insumos.Find(id);

            if (insumos == null)
            {
                return RedirectToAction("Index", "Insumos");
            }

            if (!ModelState.IsValid)
            {
                return View(insumosDto);
            }

            insumos.Nome = insumosDto.Nome;
            insumos.Fornecedor = insumosDto.Fornecedor;
            insumos.Tipo = insumosDto.Tipo;
            insumos.Quantidade = insumosDto.Quantidade;
            insumos.ValorUni = insumosDto.ValorUni;
            insumos.DataVal = insumosDto.DataVal;

            context.SaveChanges();
            return RedirectToAction("Index", "Insumos");
        }

        public IActionResult Delete(int id)
        {
            var insumos = context.Insumos.Find(id);

            if (insumos == null)
            {
                return RedirectToAction("Index", "Insumos");
            }

            context.Insumos.Remove(insumos);
            context.SaveChanges(true);
            return RedirectToAction("Index", "Insumos");
        }
    }
}
