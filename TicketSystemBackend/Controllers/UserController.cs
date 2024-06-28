using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketSystemBackend.Models;

namespace TicketSystemBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        TicketDbContext dbContext = new TicketDbContext();
        [HttpGet]
        public IActionResult GetAll()
        {
            List<User> result = dbContext.Users.ToList();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            User result = dbContext.Users.Find(id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {

            if(dbContext.Users.Any(u => u.Email.ToLower() == user.Email.ToLower()))
            {
                return Ok(dbContext.Users.FirstOrDefault(u => u.Email.ToLower() == user.Email.ToLower()));
            }
            else
            {
                user.Id = 0;
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                return Created($"/api/User/{user.Id}", user);
            }
        }
        
    }
}
