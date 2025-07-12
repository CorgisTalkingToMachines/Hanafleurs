using API.Domain.Entities;
using API.Infrastructure.EFCore.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.EFCore
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
