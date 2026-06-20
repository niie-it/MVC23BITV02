using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace Buoi04.Controllers
{
    public class FileUploadController : Controller
    {
        public IActionResult UploadFile(IFormFile myfile)
        {
            if (myfile != null)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", myfile.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    myfile.CopyTo(stream);
                }
                TempData["Message"] = "File uploaded successfully!";
            }
            else
            {
                TempData["Message"] = "No file selected.";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
