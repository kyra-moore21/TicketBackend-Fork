using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TicketSystemBackend.Models;

public partial class Ticket
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Body { get; set; }

    public string? UserOpened { get; set; }

    public string? UserClosed { get; set; }

    public bool? IsOpen { get; set; }

    public string? Resolution { get; set; }

    [JsonIgnore]
    public virtual ICollection<Bookmark> Bookmarks { get; set; } = new List<Bookmark>();
}
