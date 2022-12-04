using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ThisIsMyProve.Core.Entities.HomePageEntities;

namespace ThisIsMyProve.DataAccess
{
    public class thisIsMyProveDbContext : DbContext
    {
        public thisIsMyProveDbContext(DbContextOptions<thisIsMyProveDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Slider> Sliders { get; set; }
    }
}
