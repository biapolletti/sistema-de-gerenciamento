using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pim_Web.Models;
using Pim_Web.Services;

namespace Pim_Web.Controllers
{
    [Authorize]
    public class FornecedorController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment environment;

        public FornecedorController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }

        public IActionResult Index()
        {
            var fornecedor = context.Fornecedor.ToList();
            return View(fornecedor);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(FornecedorDto fornecedorDto)
        {
            if (!ModelState.IsValid)
            {
                return View(fornecedorDto);
            }

            Fornecedor fornecedor = new Fornecedor()
            {
                Nome = fornecedorDto.Nome,
                Email = fornecedorDto.Email,
                Cpf = fornecedorDto.Cpf,
                Telefone = fornecedorDto.Telefone,
                Endereco = fornecedorDto.Endereco,
            };

            context.Fornecedor.Add(fornecedor);
            context.SaveChanges();

            return RedirectToAction("Index", "Fornecedor");
        }

        public IActionResult Edit(int id)
        {
            var fornecedor = context.Fornecedor.Find(id);

            if (fornecedor == null)
            {
                return RedirectToAction("Index", "Fornecedor");
            }

            var fornecedorDto = new FornecedorDto()
            {
                Nome = fornecedor.Nome,
                Email = fornecedor.Email,
                Cpf = fornecedor.Cpf,
                Telefone = fornecedor.Telefone,
                Endereco = fornecedor.Endereco,
            };

            return View(fornecedorDto);
        }

        [HttpPost]
        public IActionResult Edit(int id, FornecedorDto fornecedorDto)
        {
            var fornecedor = context.Fornecedor.Find(id);

            if (fornecedor == null)
            {
                return RedirectToAction("Index", "Fornecedor");
            }

            if (!ModelState.IsValid)
            {
                return View(fornecedorDto);
            }

            fornecedor.Nome = fornecedorDto.Nome;
            fornecedor.Email = fornecedorDto.Email;
            fornecedor.Cpf = fornecedorDto.Cpf;
            fornecedor.Telefone = fornecedorDto.Telefone;
            fornecedor.Endereco = fornecedorDto.Endereco;

            context.SaveChanges();
            return RedirectToAction("Index", "Fornecedor");
        }

        public IActionResult Delete(int id)
        {
            var fornecedor = context.Fornecedor.Find(id);

            if (fornecedor == null)
            {
                return RedirectToAction("Index", "Fornecedor");
            }

            context.Fornecedor.Remove(fornecedor);
            context.SaveChanges(true);
            return RedirectToAction("Index", "Fornecedor");
        }
    }
}
