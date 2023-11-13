using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC.Core.Models;

public class SpeakerInfo
{
    public int Id { get; set; }
    public string Phone { get; set; }
    public string PhotoPath { get; set; }
    public bool MCT { get; set; }
    public bool MVP { get; set; }
    public string Biography { get; set; }
    public string Message { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public List<Event> Events { get; set; }
    public string Facebook { get; set; }
    public string Instagram { get; set; }
    public string Twitter { get; set; }
    public string Linkedin { get; set; }
    public string Website { get; set; }
    public List<Sessions> Sessions { get; set; }
}
