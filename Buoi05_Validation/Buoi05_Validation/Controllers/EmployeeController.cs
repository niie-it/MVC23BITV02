using Buoi05_Validation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Buoi05_Validation.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult IsEmployeeAvailable(string EmployeeNo)
        {
            var empNo = new List<string> { "E001", "E002", "admin" };
            if (empNo.Contains(EmployeeNo))
            {
                return Json($"Employee number {EmployeeNo} is already in use.");
            }
            return Json(true);
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Employee employee)
        {
            if (ModelState.IsValid)
            {
                //lưu file or lưu vào database
                var jsonString = JsonSerializer.Serialize(employee);
                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "employee.json");
                System.IO.File.WriteAllText(fullPath, jsonString);
            }
            return View();
        }
    }
}
