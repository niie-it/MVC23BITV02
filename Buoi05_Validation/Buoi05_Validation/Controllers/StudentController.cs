using Microsoft.AspNetCore.Mvc;

namespace Buoi05_Validation.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register()
        {
            return View("Index");
        }
    }
}
