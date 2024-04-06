using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WarehouseWithDb.Model
{
    public class ApplicationContext : DbContext
    {
        readonly StreamWriter logStream = new StreamWriter("mylog.txt", true);
        public DbSet<WarehouseDb> Warehouses { get; set; } = null!;
        public DbSet<CompanyDb> Companies { get; set; } = null!;
        public ApplicationContext()
        {
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
            optionsBuilder.LogTo(logStream.WriteLine, LogLevel.Debug);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WarehouseDb>().Property("Id").HasField("id");
            modelBuilder.Entity<WarehouseDb>().Property("Quantity").HasField("quantity");
            modelBuilder.Entity<WarehouseDb>().Property("Name").HasField("name");
            modelBuilder.Entity<WarehouseDb>().Property("Description").HasField("description");
            modelBuilder.Entity<WarehouseDb>().Property("Supplier").HasField("supplier");
            modelBuilder.Entity<CompanyDb>().Property("Id").HasField("id");
            modelBuilder.Entity<CompanyDb>().Property("Name").HasField("name");
            modelBuilder.Entity<CompanyDb>().Property("Address").HasField("address");
        }

        public override void Dispose()
        {
            base.Dispose();
            logStream.Dispose();
        }
        //public override async ValueTask DisposeAsync()
        //{
        //    await base.DisposeAsync();
        //    await logStream.DisposeAsync();
        //}
    }
}
