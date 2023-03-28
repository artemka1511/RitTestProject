using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProjectRIT.Database;
using TestProjectRIT.Objects;

namespace TestProjectRIT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private ApplicationContext _context = new ApplicationContext();

        [HttpGet]
        public IActionResult Get()
        {
            var users = _context.Users.ToList();

            if (users.Count == 0 || users is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(JsonConvert.SerializeObject(users));
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(JsonConvert.SerializeObject(user));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            var currentUser = _context.Users.Find(id);
            if (currentUser is not null)
            {
                _context.Update(user);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var currentUser = _context.Users.Find(id);
            if (currentUser is not null)
            {
                _context.Remove(currentUser);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
