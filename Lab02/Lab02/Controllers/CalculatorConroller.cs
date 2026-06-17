using Microsoft.AspNetCore.Mvc;

namespace Lab02.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calculate(double SoHang01, double SoHang02, string ToanTu)
        {
            double result = 0;
            switch (ToanTu)
            {
                case "+": result = SoHang01 + SoHang02; break;
                case "-": result = SoHang01 - SoHang02; break;
                case "*": result = SoHang01 * SoHang02; break;
                case "/":
                    if (SoHang02 == 0)
                    {
                        // Handle division by zero
                        ViewData["Error"] = "Cannot divide by zero";
                    }
                    else
                    {
                        result = SoHang01 / SoHang02;
                    }
                    break;
            }
            ViewData["Result"] = result;
            ViewBag.SoHang01 = SoHang01;
            ViewBag.SoHang02 = SoHang02;
            ViewBag.ToanTu = ToanTu;
            return View("Index");
        }
    }
}
