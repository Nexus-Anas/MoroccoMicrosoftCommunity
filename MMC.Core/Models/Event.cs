using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC.Core.Models;

public class Event
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImagePath { get; set; }
    public string Description { get; set; }
    public DateTime Du { get; set; }
    public DateTime Au { get; set; }
    public string Type { get; set; }
    public int CityId { get; set; }
    public City City { get; set; }
    public string Address { get; set; }
    public int CategorieId { get; set; }
    public Categorie Categorie { get; set; }
    public int nbPlace { get; set; }

    public List<SpeakerInfo> SpeakerInfos { get; set; }
    public List<Sponsor> Sponsors { get; set; }
    public string Facebook { get; set; }
    public string Instagram { get; set; }
    public string Twitter { get; set; }
    public string Linkedin { get; set; }
    public string Website { get; set; }
}
