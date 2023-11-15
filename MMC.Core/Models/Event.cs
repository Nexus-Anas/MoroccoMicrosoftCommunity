using System.Text.Json.Serialization;

namespace MMC.Core.Models;

public class Event
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? ImagePath { get; set; }
    public string? Description { get; set; }
    public required DateTime Du { get; set; }
    public required DateTime Au { get; set; }
    public required string Type { get; set; }
    public int CityId { get; set; }
    [JsonIgnore]
    public City? City { get; set; }
    public string? Address { get; set; }
    public int CategorieId { get; set; }
    [JsonIgnore]
    public Category? Categorie { get; set; }
    public int NbPlace { get; set; }
    [JsonIgnore]
    public List<Speaker>? SpeakerInfos { get; set; }
    [JsonIgnore]
    public List<Sponsor>? Sponsors { get; set; }
    [JsonIgnore]
    public List<Session>? Sessions { get; set; }
    public string? Facebook { get; set; }
    public string? Instagram { get; set; }
    public string? Twitter { get; set; }
    public string? Linkedin { get; set; }
    public string? Website { get; set; }
    [JsonIgnore]
    public List<Participant>? Participants { get; set; }
}
