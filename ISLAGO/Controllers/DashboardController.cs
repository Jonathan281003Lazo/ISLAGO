using Microsoft.AspNetCore.Mvc;

namespace ISLAGO.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
