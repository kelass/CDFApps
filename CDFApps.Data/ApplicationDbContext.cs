using CDFApps.Domain.dbModels;
using Microsoft.EntityFrameworkCore;

namespace CDFApps.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<WarehouseJobs> WarehouseJobs { get; set; }
        public DbSet<Boxes> Boxes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            Database.Migrate();
        }
    }
}