using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Magazyn.Models
{
    public class MagazynDBContext : DbContext
    {

        public DbSet<Akcesoria> Akcesoria { get; set; }
        public DbSet<Plyty> Plyty { get; set; }
        public DbSet<Prowadnice> Prowadnice { get; set; }
        public DbSet<RozmiaryPlyt> RozmiaryPlyt { get; set; }
        public DbSet<Uchwyty> Uchwyty { get; set; }
        public DbSet<Zawiasy> Zawiasy { get; set; }

        public MagazynDBContext(DbContextOptions options) : base(options) { }
    }
}