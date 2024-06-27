using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketSystemBackend.Models;

namespace TicketSystemBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        TicketDbContext dbContext = new TicketDbContext();
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Comment> result = dbContext.Comments.Include(c => c.User).ToList();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Comment result = dbContext.Comments.Include(c => c.User).FirstOrDefault(c => c.Id == id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddUser([FromBody] Comment comment)
        {
            comment.Id = 0;
            dbContext.Comments.Add(comment);
            dbContext.SaveChanges();
            return Created($"/api/Comment/{comment.Id}", comment);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            Comment result = dbContext.Comments.Find(id);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                dbContext.Comments.Remove(result);
                dbContext.SaveChanges();
                return NoContent();
            }
        }
    }

}
