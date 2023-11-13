using System.Text.Json.Serialization;

namespace MMC.Core.Models;

public class Session
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required DateTime Du { get; set; }
    public required DateTime Au { get; set; }
    public int EventId { get; set; }
    [JsonIgnore]
    public Event? Event { get; set; }
}
