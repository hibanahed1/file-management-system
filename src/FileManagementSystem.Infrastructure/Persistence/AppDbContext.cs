using Microsoft.EntityFrameworkCore;
using FileManagementSystem.Domain.Entities;

namespace FileManagementSystem.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<FileItem> Files { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
