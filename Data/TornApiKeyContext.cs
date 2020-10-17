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

        public DbSet<ApiKeyStorageService.Model.TornApiKey> TornApiKey { get; set; }
    }
}
