using System.Text.Json.Serialization;

namespace MMC.Core.Models;

public class Sponsor
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? LogoPath { get; set; }
    [JsonIgnore]
    public List<Event>? Events { get; set; }
}
