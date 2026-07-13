using Buoi13_APIOnly.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Buoi13_APIOnly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        static List<User> users = new List<User>()
        {
            new User{ Id = Guid.NewGuid(), UserName = "user1", Password = "pass1" },
            new User{ Id = Guid.NewGuid(), UserName = "user2", Password = "pass2" },
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
