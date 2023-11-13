using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC.Core.Models;

public class Sessions
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Du { get; set; }
    public DateTime Au { get; set; }
    public int EventId { get; set; }
    public Event Event { get; set; }
}
