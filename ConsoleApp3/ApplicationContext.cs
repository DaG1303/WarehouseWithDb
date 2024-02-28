using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WarehouseWithDb
{
    class ApplicationContext : DbContext
    {
        public DbSet<Warehouse> Warehouse => Set<Warehouse>();
        public ApplicationContext():base()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false).Build();

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(config.GetConnectionString("DefaultConnection"));
            }
            optionsBuilder.LogTo(Console.WriteLine);
            //optionsBuilder.UseSqlite("Data Source=helloapp.db");

            //var config = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json")
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .Build();
            //optionsBuilder.UseSqlite(config.GetConnectionString("DefaultConnection"));
        }
    }
}
