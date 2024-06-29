using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSystemBackend.Models;
using Microsoft.EntityFrameworkCore;
using TicketSystemBackend.DTO;

namespace TicketSystemBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarkController : ControllerBase
    {
        TicketDbContext dbContext = new TicketDbContext();

        [HttpGet()]
        public IActionResult GetBookmarks()
        {
            return Ok(dbContext.Bookmarks.Include(b => b.Ticket).ToList());
        }

        [HttpGet("getById")]
        public async Task<ActionResult<Bookmark>> GetBookmarkById(int userId, int ticketId)
        {
            Bookmark result = await dbContext.Bookmarks.FirstOrDefaultAsync(b => b.UserBookmarked == userId && b.TicketId == ticketId);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result.Id);
        }
        [HttpGet("bookmarked")]
        public IActionResult GetBookmarked(int userId, int ticketId)
        {
            Boolean result = dbContext.Bookmarks.Any(b => b.UserBookmarked == userId && b.TicketId == ticketId);
            return Ok(result);

        }
        
        [HttpPost()]
        public IActionResult AddBookmark(BookmarkDTO bookmarkDTO)
        {
            Bookmark newBookmark = new Bookmark
            {
                TicketId = bookmarkDTO.ticketId,
                UserBookmarked = bookmarkDTO.userBookmarkedId,
                Ticket = dbContext.Tickets.Find(bookmarkDTO.ticketId)
            };

            dbContext.Bookmarks.Add(newBookmark);
            dbContext.SaveChanges();
            return Created("", newBookmark);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBookmark(int id)
        {
            Bookmark result = dbContext.Bookmarks.Find(id);
            if(result == null)
            {
                return NotFound();
            }
            else
            {
                dbContext.Bookmarks.Remove(result);
                dbContext.SaveChanges();
                return NoContent();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBookmark(int id, BookmarkDTO bookmarkDTO)
        {
            Bookmark updatedBookmark = dbContext.Bookmarks.Find(id);

            if (updatedBookmark == null)
            {
                return NotFound();
            }
            else if(!dbContext.Tickets.Any(t => t.Id == bookmarkDTO.ticketId))
            {
                return BadRequest();
            }
            else
            {
                updatedBookmark.TicketId = bookmarkDTO.ticketId;
                updatedBookmark.UserBookmarked = bookmarkDTO.userBookmarkedId;
                updatedBookmark.Ticket = dbContext.Tickets.Find(bookmarkDTO.ticketId);
                dbContext.Bookmarks.Update(updatedBookmark);
                dbContext.SaveChanges();
                return NoContent();
            }
        }
    }
}
