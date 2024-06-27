using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSystemBackend.DTO;
using TicketSystemBackend.Models;

namespace TicketSystemBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        TicketDbContext dbContext = new TicketDbContext();

        [HttpGet()]
        public IActionResult GetTickets()
        {
            return Ok(dbContext.Tickets.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetTicketById(int id)
        {
            Ticket result = dbContext.Tickets.Find(id);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPost()]
        public IActionResult AddTicket(TicketDTO ticketDTO)
        {
            Ticket newTicket = new Ticket
            {
                Title = ticketDTO.title,
                Body = ticketDTO.body,
                UserOpenId= ticketDTO.userOpenedId,
                IsOpen = true
            };

            dbContext.Tickets.Add(newTicket);
            dbContext.SaveChanges();
            return Created($"/Api/Ticket/{newTicket.Id}", newTicket);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTicket(int id)
        {
            Ticket result = dbContext.Tickets.Find(id);
            if(result == null)
            {
                return NotFound();
            }
            else
            {
                dbContext.Tickets.Remove(result);
                dbContext.SaveChanges();
                return NoContent();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTicket(int id, [FromBody] Ticket updatedTicket)
        {
            if(updatedTicket.Id != id)
            {
                return BadRequest();
            }
            else if(!dbContext.Tickets.Any(t => t.Id == id))
            {
                return NotFound();
            }
            else
            {
                dbContext.Tickets.Update(updatedTicket);
                dbContext.SaveChanges();
                return NoContent();
            }
        }
    }
}
