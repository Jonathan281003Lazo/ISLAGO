using Microsoft.AspNetCore.Mvc;

namespace ISLAGO.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
