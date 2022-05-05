using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                "AttachDbFilename="+Path.GetFullPath("MAGAZYN.mdf") +
                ";Integrated Security=True;";
            optionsBuilder.UseSqlServer(temp,options => options.EnableRetryOnFailure());
        }
    }
}
