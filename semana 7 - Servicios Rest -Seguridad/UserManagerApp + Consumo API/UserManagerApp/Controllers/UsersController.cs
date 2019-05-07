using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagerApp.Models;

namespace UserManagerApp.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class UsersController : ControllerBase
    {
        static List<User> users = new List<User>
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

        // POST: api/users
        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            try
            {
                users.Add(user);

                return Created("/users/" + user.IdUser, user);
            }
            catch (Exception)
            {

                return NotFound();
            }

        }

        // PUT: api/users/2
        [HttpPut("{id}")]
        public IActionResult EditUser(int id, [FromBody] User user)
        {
            try
            {
                var userOld = users.FirstOrDefault((p) => p.IdUser == id);
                if (userOld != null)
                {
                    userOld.Name = user.Name;
                    userOld.Password = user.Password;
                    userOld.UserName = user.UserName;
                    userOld.ModifiedDate = DateTime.Now;
                    return Ok(user);
                }
                return NotFound();
            }
            catch (Exception)
            {

                return NotFound();
            }

        }

        // PUT: api/users/2
        [HttpPatch("{id}")]
        public IActionResult EditPatchUser(int id, [FromBody] User user)
        {
            try
            {
                var userOld = users.FirstOrDefault((p) => p.IdUser == id);
                if (userOld != null)
                {
                    if (!string.IsNullOrEmpty(user.Name))
                        userOld.Name = user.Name;
                    if (!string.IsNullOrEmpty(user.Password))
                        userOld.Password = user.Password;
                    if (!string.IsNullOrEmpty(user.UserName))
                        userOld.UserName = user.UserName;

                    userOld.ModifiedDate = DateTime.Now;
                    return Ok(user);
                }
                return NotFound();
            }
            catch (Exception)
            {

                return NotFound();
            }

        }

        // DELETE: api/users/2
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                if (users.RemoveAll((p) => p.IdUser == id) > 0)
                {
                    return Ok();
                }
                return NotFound();

            }
            catch (Exception)
            {

                return NotFound();
            }

        }
    }
}