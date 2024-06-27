using System;
using System.Collections.Generic;

namespace TicketSystemBackend.Models;

public partial class User
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PhotoUrl { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Bookmark> Bookmarks { get; set; } = new List<Bookmark>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Ticket> TicketUserCloseds { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketUserOpens { get; set; } = new List<Ticket>();
}
