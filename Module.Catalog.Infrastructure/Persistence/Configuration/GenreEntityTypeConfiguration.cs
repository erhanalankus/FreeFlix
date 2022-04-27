using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module.Catalog.Core.Entities;

namespace Module.Catalog.Infrastructure.Persistence.Configuration
{
    public class GenreEntityTypeConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.Property(g => g.Name).IsRequired();

            builder.HasData(
                new Genre { Id = 1, Name = "Drama" },
                new Genre { Id = 2, Name = "Adventure" },
                new Genre { Id = 3, Name = "War" });
        }
    }
}
