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
        [HttpGet]
        public IActionResult Get()
        {
            using (var db = new ApplicationContext())
            {
                var users = db.Users.ToList();
                if (users.Count == 0 || users is null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(JsonConvert.SerializeObject(users));
                }
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            using (var db = new ApplicationContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }

            return Ok(JsonConvert.SerializeObject(user));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            using (var db = new ApplicationContext())
            {
                var currentUser = db.Users.Find(id);
                if (currentUser is not null)
                {
                    db.Update(user);
                    db.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }

            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (var db = new ApplicationContext())
            {
                var currentUser = db.Users.Find(id);
                if(currentUser is not null)
                {
                    db.Remove(currentUser);
                    db.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
                
            }
        }
    }
}
