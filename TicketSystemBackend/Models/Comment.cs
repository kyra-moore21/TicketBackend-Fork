using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TicketSystemBackend.Models;

public partial class Comment
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Body { get; set; }

    public int? TicketId { get; set; }

    [JsonIgnore]
    public virtual Ticket? Ticket { get; set; }

    [JsonIgnore]
    public virtual User? User { get; set; }
}
