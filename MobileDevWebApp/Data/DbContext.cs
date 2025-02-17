using Microsoft.EntityFrameworkCore;

namespace MobileDevWebApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


    }
}
