using Lab02.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab02.Controllers
{
    public class CoursesController : Controller
    {
        static List<Course> courses = new List<Course>()
        {
            new Course{CourseId=1, CourseName="ASP.NET Core", Credit=3, TheoryHours=30},
            new Course{CourseId=2, CourseName="Windows Form", Credit=3, TheoryHours=15}
        };
        public IActionResult Index()
        {
            return View(courses);
        }
    }
}
