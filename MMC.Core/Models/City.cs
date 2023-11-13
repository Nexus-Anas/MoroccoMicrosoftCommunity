﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC.Core.Models;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Event> Events { get; set; }
}
