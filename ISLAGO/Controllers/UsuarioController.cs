using Microsoft.AspNetCore.Mvc;

namespace ISLAGO.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
