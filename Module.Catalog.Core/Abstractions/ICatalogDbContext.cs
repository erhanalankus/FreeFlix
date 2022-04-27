using Microsoft.EntityFrameworkCore;
using Module.Catalog.Core.Entities;

namespace Module.Catalog.Core.Abstractions
{
    /// <summary>
    /// Interface to achieve Dependency Inversion.
    /// </summary>
    public interface ICatalogDbContext
    {
        public DbSet<Movie> Movies { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
