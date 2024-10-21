using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pim_Web.Models;
using Pim_Web.Services;

namespace Pim_Web.Controllers
{
    [Authorize]
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment environment;

        public ClientesController(ApplicationDbContext context, IWebHostEnvironment environment) 
        { 
            this.context = context;
            this.environment = environment;
        }
       
        public IActionResult Index()
        {
            var clientes = context.Clientes.ToList();
            return View(clientes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ClientesDto clientesDto)
        {
            if (!ModelState.IsValid)
            {
                return View(clientesDto);
            }

            Clientes clientes = new Clientes()
            {
                Nome = clientesDto.Nome,
                Email = clientesDto.Email,
                Cpf = clientesDto.Cpf,
                Telefone = clientesDto.Telefone,
                Endereco = clientesDto.Endereco,
            };

            context.Clientes.Add(clientes);
            context.SaveChanges();
            
            return RedirectToAction("Index", "Clientes");
        }

        public IActionResult Edit(int id)
        {
            var clientes = context.Clientes.Find(id);

            if (clientes == null)
            {
                return RedirectToAction("Index", "Clientes");
            }

            var clientesDto = new ClientesDto()
            {
                Nome = clientes.Nome,
                Email = clientes.Email,
                Cpf = clientes.Cpf,
                Telefone = clientes.Telefone,
                Endereco = clientes.Endereco,
            };

            return View(clientesDto);
        }

        [HttpPost]
        public IActionResult Edit(int id, ClientesDto clientesDto)
        {
            var clientes = context.Clientes.Find(id);

            if (clientes == null)
            {
                return RedirectToAction("Index", "Clientes");
            }

            if (!ModelState.IsValid)
            {
                return View(clientesDto);
            }

            clientes.Nome = clientesDto.Nome;
            clientes.Email = clientesDto.Email;
            clientes.Cpf = clientesDto.Cpf;
            clientes.Telefone = clientesDto.Telefone;
            clientes.Endereco = clientesDto.Endereco;

            context.SaveChanges();
            return RedirectToAction("Index", "Clientes");
        }

        public IActionResult Delete(int id)
        {
            var clientes = context.Clientes.Find(id);

            if (clientes == null)
            {
                return RedirectToAction("Index", "Clientes");
            }

            context.Clientes.Remove(clientes);
            context.SaveChanges(true);
            return RedirectToAction("Index", "Clientes");
        }
    }
}
