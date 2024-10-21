using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pim_Web.Models;
using Pim_Web.Services;

namespace Pim_Web.Controllers
{
    [Authorize]
    public class OfertasController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment environment;

        public OfertasController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }

        public IActionResult Index()
        {
            var ofertas = context.Ofertas.ToList();
            return View(ofertas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(OfertasDto ofertasDto)
        {
            if (!ModelState.IsValid)
            {
                return View(ofertasDto);
            }

            Ofertas ofertas = new Ofertas()
            {
                Nome = ofertasDto.Nome,
                Conteudo = ofertasDto.Conteudo,
                Valor = ofertasDto.Valor,
            };

            context.Ofertas.Add(ofertas);
            context.SaveChanges();

            return RedirectToAction("Index", "Ofertas");
        }

        public IActionResult Edit(int id)
        {
            var ofertas = context.Ofertas.Find(id);

            if (ofertas == null)
            {
                return RedirectToAction("Index", "Ofertas");
            }

            var ofertasDto = new OfertasDto()
            {
                Nome = ofertas.Nome,
                Conteudo = ofertas.Conteudo,
                Valor = ofertas.Valor,
            };

            return View(ofertasDto);
        }

        [HttpPost]
        public IActionResult Edit(int id, OfertasDto ofertasDto)
        {
            var ofertas = context.Ofertas.Find(id);

            if (ofertas == null)
            {
                return RedirectToAction("Index", "Ofertas");
            }

            if (!ModelState.IsValid)
            {
                return View(ofertasDto);
            }

            ofertas.Nome = ofertasDto.Nome;
            ofertas.Conteudo = ofertasDto.Conteudo;
            ofertas.Valor = ofertasDto.Valor;

            context.SaveChanges();
            return RedirectToAction("Index", "Ofertas");
        }

        public IActionResult Delete(int id)
        {
            var ofertas = context.Ofertas.Find(id);

            if (ofertas == null)
            {
                return RedirectToAction("Index", "Ofertas");
            }

            context.Ofertas.Remove(ofertas);
            context.SaveChanges(true);
            return RedirectToAction("Index", "Ofertas");
        }
    }
}
