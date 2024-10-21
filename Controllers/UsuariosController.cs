using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pim_Web.Models;
using Pim_Web.Services;
using Pim_Web.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Pim_Web.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _appDbContext;

        public UsuariosController(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(UsuariosVM modelo)
        {
            if (modelo.Password != modelo.ConPassword)
            {
                ViewData["Mensagem"] = "As senhas não coincidem!";
                return View();
            }

            Usuarios usuarios = new Usuarios()
            {
                Name = modelo.Name,
                Email = modelo.Email,
                Telefone = modelo.Telefone,
                Adress = modelo.Adress,
                Cpf = modelo.Cpf,
                DataNasc = modelo.DataNasc,
                Password = modelo.Password
            };

            await _appDbContext.Usuarios.AddAsync(usuarios);
            await _appDbContext.SaveChangesAsync();

            if (usuarios.Id != 0) return RedirectToAction("Login", "Usuarios");

            ViewData["Mensagem"] = "Não foi possível cadastrar o usuário!";
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM modelo)
        {
            Usuarios? usuario_encontrado = await _appDbContext.Usuarios
                .Where(u => u.Name == modelo.Name && u.Password == modelo.Password)
                .FirstOrDefaultAsync();

            if (usuario_encontrado == null)
            {
                ViewData["Mensagem"] = "Usuário não cadastrado!";
                return View();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuario_encontrado.Name)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties);

            return RedirectToAction("Index", "Home");
        }
    }
}
