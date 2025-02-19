using Microsoft.EntityFrameworkCore;
using MobileDevWebApp.Models;

namespace MobileDevWebApp.Data
{
    public class AppDbContext : DbContext
    {
        private string connectionString = "Data Source=DESKTOP-DN719RO\\PRACTICEDB1;Integrated Security=True; Initial Catalog=Tea; Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<TeaM> Tea { get; set; }
        public DbSet<SupplierM> Supplier { get; set; }
        public DbSet<InventoryM> Inventory { get; set; }


    }
}
