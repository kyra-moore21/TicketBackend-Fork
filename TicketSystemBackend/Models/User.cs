using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TicketSystemBackend.Models;

public partial class User
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PhotoUrl { get; set; }

    public string? Email { get; set; }

    [JsonIgnore]
    public virtual ICollection<Bookmark> Bookmarks { get; set; } = new List<Bookmark>();

    [JsonIgnore]
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    [JsonIgnore]
    public virtual ICollection<Ticket> TicketUserClosedNavigations { get; set; } = new List<Ticket>();

    [JsonIgnore]
    public virtual ICollection<Ticket> TicketUserOpenedNavigations { get; set; } = new List<Ticket>();
}
