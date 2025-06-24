using Microsoft.EntityFrameworkCore;
using PocAPI.Entities;

namespace PocAPI.Data
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options) { }

        public DbSet<DemoEntity> DemoEntities { get; set; }
    }
}
