using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MMC.Core.Models;

public class Speaker
{
    public int Id { get; set; }
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public required string Mail { get; set; }
    public required string Password { get; set; }
    public required string Phone { get; set; }
    public string PhotoPath { get; set; }
    public bool MCT { get; set; }
    public bool MVP { get; set; }
    public string Biography { get; set; }
    public string Message { get; set; }
    [JsonIgnore]
    public List<Event>? Events { get; set; }
    public string? Facebook { get; set; }
    public string? Instagram { get; set; }
    public string? Twitter { get; set; }
    public string? Linkedin { get; set; }
    public string? Website { get; set; }
    [JsonIgnore]
    public List<Session>? Sessions { get; set; }
}
