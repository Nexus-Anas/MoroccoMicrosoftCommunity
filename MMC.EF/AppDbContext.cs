using Microsoft.EntityFrameworkCore;
using MMC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC.EF;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }




    public DbSet<Categorie> Categorias { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Participant> Participants { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<SpeakerInfo> SpeakerInfos { get; set;}
    public DbSet<Sponsor> Sponsors { get; set; }
    public DbSet<User> Users { get; set; }
}
