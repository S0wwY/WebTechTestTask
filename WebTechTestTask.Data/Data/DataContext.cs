using Microsoft.EntityFrameworkCore;
using WebTechTestTask.Models;

namespace WebTechTestTask.Data.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role[]
                {
                    new Role{Id = 1, RoleName = "User"},
                    new Role{Id = 2, RoleName = "Admin"},
                    new Role{Id = 3, RoleName = "Support"},
                    new Role{Id = 4, RoleName = "SuperAdmin"}
                });
        }
    }
}
