using Microsoft.EntityFrameworkCore;
using SimpleTimeTracker.Core.Models;

namespace SimpleTimeTracker.Core.DbContexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) 
            : base(options)
        { }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Claim> Claims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUser");
            modelBuilder.Entity<Claim>().ToTable("Claim");
        }
    }
}
