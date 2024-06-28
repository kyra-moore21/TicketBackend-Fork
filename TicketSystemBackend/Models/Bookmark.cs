using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TicketSystemBackend.Models;

public partial class Bookmark
{
    public int Id { get; set; }

    public int? TicketId { get; set; }

    public int? UserBookmarked { get; set; }

    public virtual Ticket? Ticket { get; set; }

    [JsonIgnore]
    public virtual User? UserBookmarkedNavigation { get; set; }
}
