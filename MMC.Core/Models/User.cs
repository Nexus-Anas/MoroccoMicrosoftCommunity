using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC.Core.Models;


public class User
{
    public int Id { get; set; }
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public required string Mail { get; set; }
    public required string Password { get; set; }
    public required string Role { get; set; }
}
