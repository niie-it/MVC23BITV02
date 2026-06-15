using Buoi02_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Buoi02_MVC.Controllers
{
    public class HomeController : Controller
    {
        [Route("/hello-world")]
        public IActionResult Index()
        {
            return View();
        }

        // ~/Home/ActionTest
        public string ActionTest()
        {
            return "Hello World";
        }

        // ~/Home/Hello?name=Ronaldo
        // ~/Home/Hello
        public IActionResult Hello(string name = "David")
        {
            return Content($"Hello {name}");
        }

        // ~/Home/ActionIndex
        public IActionResult ActionIndex()
        {
            return View("MyView");
        }

        public IActionResult MyData()
        {
            return Json(new
            {
                Name = "David",
                Age = 30
            });
        }

        [Route("/google")]
        public IActionResult Google()
        {
            return Redirect("https://www.google.com");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
