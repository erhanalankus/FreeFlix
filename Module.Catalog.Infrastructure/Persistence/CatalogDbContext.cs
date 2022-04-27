using Microsoft.EntityFrameworkCore;
using Module.Catalog.Core.Abstractions;
using Module.Catalog.Core.Entities;
using Shared.Infrastructure.Persistence;

namespace Module.Catalog.Infrastructure.Persistence
{
    /// <summary>
    /// No other modules can have access to Movies, Genres, and Actors tables other than the Catalog Module. This is made sure by creating separate DbContexts for each Module.
    /// </summary>
    public class CatalogDbContext : ModuleDbContext, ICatalogDbContext
    {
        protected override string Schema => "Catalog";

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
