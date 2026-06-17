using Microsoft.AspNetCore.Mvc;

namespace Lab02.Controllers
{
    public class CalculatorConroller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
