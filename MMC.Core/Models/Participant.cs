using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC.Core.Models;

public class Participant
{
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Mail { get; set; }
    public string Phone { get; set; }
    public string Company { get; set; }
    public char Gender { get; set; }
    public string Message { get; set; }
}
