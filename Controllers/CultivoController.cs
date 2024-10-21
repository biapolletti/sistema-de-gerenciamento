using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Pim_Web.Controllers
{
    [Authorize]
    public class CultivoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
