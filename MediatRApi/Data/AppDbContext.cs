using MediatRApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediatRApi.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<DemoEntity> DemoEntities { get; set; }
    }

}
