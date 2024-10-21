using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pim_Web.Models;
using Pim_Web.Services;

namespace Pim_Web.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment environment;

        public ProdutosController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }

        public IActionResult Index()
        {
            var produtos = context.Produtos.ToList();
            return View(produtos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProdutosDto produtosDto)
        {
            if (!ModelState.IsValid)
            {
                return View(produtosDto);
            }

            Produtos produtos = new Produtos()
            {
                Nome = produtosDto.Nome,
                Tipo = produtosDto.Tipo,
                Quantidade = produtosDto.Quantidade,
                ValorUni = produtosDto.ValorUni,
                DataVal = produtosDto.DataVal,
            };

            context.Produtos.Add(produtos);
            context.SaveChanges();

            return RedirectToAction("Index", "Produtos");
        }

        public IActionResult Edit(int id)
        {
            var produtos = context.Produtos.Find(id);

            if (produtos == null)
            {
                return RedirectToAction("Index", "Produtos");
            }

            var produtosDto = new ProdutosDto()
            {
                Nome = produtos.Nome,
                Tipo = produtos.Tipo,
                Quantidade = produtos.Quantidade,
                ValorUni = produtos.ValorUni,
                DataVal = produtos.DataVal,
            };

            return View(produtosDto);
        }

        [HttpPost]
        public IActionResult Edit(int id, ProdutosDto produtosDto)
        {
            var produtos = context.Produtos.Find(id);

            if (produtos == null)
            {
                return RedirectToAction("Index", "Produtos");
            }

            if (!ModelState.IsValid)
            {
                return View(produtosDto);
            }

            produtos.Nome = produtosDto.Nome;
            produtos.Tipo = produtosDto.Tipo;
            produtos.Quantidade = produtosDto.Quantidade;
            produtos.ValorUni = produtosDto.ValorUni;
            produtos.DataVal = produtosDto.DataVal;

            context.SaveChanges();
            return RedirectToAction("Index", "Produtos");
        }

        public IActionResult Delete(int id)
        {
            var produtos = context.Produtos.Find(id);

            if (produtos == null)
            {
                return RedirectToAction("Index", "Produtos");
            }

            context.Produtos.Remove(produtos);
            context.SaveChanges(true);
            return RedirectToAction("Index", "Produtos");
        }
    }
}
