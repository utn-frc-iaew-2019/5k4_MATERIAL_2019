using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagerApp.Models;

namespace UserManagerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        List<User> users = new List<User>
        {
            new User { IdUser = 1, Name = "Juan Perez",
                       UserName = "juan.perez", Password = "pass123",
                       ModifiedDate = DateTime.Now},
            new User { IdUser = 2, Name = "Esteban Ruiz",
                       UserName = "esteban.ruiz", Password = "pass123",
                       ModifiedDate = DateTime.Now},
            new User { IdUser = 3, Name = "Ricardo Rodriguez",
                       UserName = "ricardo.rodriguez", Password = "pass123",
                       ModifiedDate = DateTime.Now},
        };

        [HttpGet]
        public List<User> GetAllUsers()
        {
            return users;
        }

        // GET: api/users/3
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = users.FirstOrDefault((p) => p.IdUser == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

    }
}