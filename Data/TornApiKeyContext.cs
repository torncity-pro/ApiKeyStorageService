using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiKeyStorageService.Model;

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

            /*
            modelBuilder.Entity<TornApiKey>().Property(a => a.Key)
                .HasConversion(dbin => SecretsUtil.EncryptString(dbin), dbout => SecretsUtil.DecryptString(dbout)); // Used for encrpyting and decrypting a string
            */
        }

        public DbSet<TornApiKey> TornApiKey { get; set; }
    }
}
