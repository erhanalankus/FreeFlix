using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module.Catalog.Core.Entities;

namespace Module.Catalog.Infrastructure.Persistence.Configuration
{
    public class ActorEntityTypeConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(a => a.FirstName).IsRequired();
            builder.Property(a => a.LastName).IsRequired();
            builder.Property(a => a.FullName).IsRequired();

            builder.Property(a => a.FullName)
                .HasComputedColumnSql(@"[FirstName] + ' ' + (CASE WHEN [MiddleName] IS NULL THEN '' ELSE ([MiddleName] + ' ') END) + [LastName]", stored: true);

            builder.HasData(
                new Actor { Id = 1, FirstName = "Brad", LastName = "Pitt" },
                new Actor { Id = 2, FirstName = "Edward", LastName = "Norton" },
                new Actor { Id = 3, FirstName = "Helena", MiddleName = "Bonham", LastName = "Carter" },
                new Actor { Id = 4, FirstName = "Diane", LastName = "Kruger" },
                new Actor { Id = 5, FirstName = "Eli", LastName = "Roth" });
        }
    }
}
