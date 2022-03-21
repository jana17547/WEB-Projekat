using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class AutoSkolaContext : DbContext
    {
        public DbSet<AutoSkola> AutoSkole {get; set;}
        public DbSet<Kategorija> Kategorije {get; set;}
        public DbSet<Polaze> PolazeKategoriju {get; set;}
        public DbSet<Instruktor> Instruktori {get; set;}
        public DbSet<Kandidat> Kandidati {get; set;}

        public AutoSkolaContext(DbContextOptions options) : base(options)
        {

        }

    }
}