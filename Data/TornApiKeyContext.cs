using ApiKeyStorageService.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiKeyStorageService.Data
{
    public class TornApiKeyContext : DbContext
    {
        public TornApiKeyContext (DbContextOptions<TornApiKeyContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TornApiKey>().HasKey(a => a.PlayerId);
            modelBuilder.Entity<TornApiKey>().Property(a => a.PlayerId)
                .ValueGeneratedNever();
            modelBuilder.Entity<TornApiKey>().Property(a => a.ApiKey)
                .IsRequired(true);
            modelBuilder.Entity<TornApiKey>().HasIndex(a => a.ApiKey)
                .IsUnique(true);
        }

        public DbSet<TornApiKey> TornApiKey { get; set; }
    }
}
