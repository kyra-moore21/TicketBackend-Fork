using System;
using System.Collections.Generic;

namespace TicketSystemBackend.Models;

public partial class Ticket
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Body { get; set; }

    public bool? IsOpen { get; set; }

    public string? Resolution { get; set; }

    public int? UserOpenId { get; set; }

    public int? UserClosedId { get; set; }

    public virtual ICollection<Bookmark> Bookmarks { get; set; } = new List<Bookmark>();

    public virtual User? UserClosed { get; set; }

    public virtual User? UserOpen { get; set; }
}
