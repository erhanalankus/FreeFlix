using Microsoft.EntityFrameworkCore;

namespace Shared.Infrastructure.Persistence;

/// <summary>
/// This will be the base of all the DbContext classes in each and every module.
/// </summary>
public abstract class ModuleDbContext : DbContext
{
    /// <summary>
    /// We are using Schemas to make a logical separation between the database tables. For example, tables associated with Catalog module will be named Catalog.Movies, etc.
    /// </summary>
    protected abstract string Schema { get; }

    protected ModuleDbContext(DbContextOptions options) : base(options)
    { 
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (!string.IsNullOrWhiteSpace(Schema))
        {
            modelBuilder.HasDefaultSchema(Schema);
        }

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return (await base.SaveChangesAsync(true, cancellationToken));
    }
}
