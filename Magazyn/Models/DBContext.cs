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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string temp = "Data Source=(LocalDB)\\MSSQLLocalDB;" +
                "AttachDbFilename=" + Path.GetFullPath("MAGAZYN.mdf") +
                ";Integrated Security=True;";
            optionsBuilder.UseSqlServer(temp, options => options.EnableRetryOnFailure());
        }
    }
}