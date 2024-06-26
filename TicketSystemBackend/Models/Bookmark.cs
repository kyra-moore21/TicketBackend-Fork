using System;
using System.Collections.Generic;

namespace TicketSystemBackend.Models;

public partial class Bookmark
{
    public int Id { get; set; }

    public int? TicketId { get; set; }

    public string? UserBookmarked { get; set; }

    public virtual Ticket? Ticket { get; set; }
}
