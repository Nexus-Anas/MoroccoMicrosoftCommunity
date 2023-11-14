using System.Text.Json.Serialization;

namespace MMC.Core.Models;

public class Category
{
    public int Id { get; set; }
    public required string Name { get; set; }
    [JsonIgnore]
    public List<Event>? Events { get; set; }
}
