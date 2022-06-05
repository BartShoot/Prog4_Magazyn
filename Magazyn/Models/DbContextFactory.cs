using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn.Models
{
    public class DbContextFactory : IDesignTimeDbContextFactory<MagazynDBContext>
    {
        public MagazynDBContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<MagazynDBContext>();
            string temp = "Data Source=(localdb)\\MSSQLLocalDB;" +
                "Initial Catalog=D:\\STUDIA\\PROG4\\BAZA\\MAGAZYN\\MAGAZYN\\MAGAZYN.MDF;" +
                "Integrated Security=True;Connect Timeout=30;Encrypt=False;" +
                "TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            options.UseSqlServer(temp);
            return new MagazynDBContext(options.Options);
        }
    }
}
