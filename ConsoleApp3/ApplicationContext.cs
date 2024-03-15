using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WarehouseWithDb
{
    public class ApplicationContext : DbContext
    {
        readonly StreamWriter logStream = new StreamWriter("mylog.txt", true);
        public DbSet<Warehouse> Warehouses { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;
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
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Ignore<Company>();
        }

        public override void Dispose()
        {
            base.Dispose();
            logStream.Dispose();
        }
        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
            await logStream.DisposeAsync();
        }
    }
}
