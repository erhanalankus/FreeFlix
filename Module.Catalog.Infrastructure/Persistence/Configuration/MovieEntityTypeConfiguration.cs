using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module.Catalog.Core.Entities;

namespace Module.Catalog.Infrastructure.Persistence.Configuration
{
    public class MovieEntityTypeConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(m => m.Title).IsRequired();
            builder.Property(m => m.Year).IsRequired();
            builder.Property(m => m.Synopsis).IsRequired();
            builder.Property(m => m.Director).IsRequired();

            builder.HasData(
                new Movie
                {
                    Id = 1,
                    Title = "Fight Club",
                    Director = "David Fincher",
                    Synopsis = "An insomniac office worker and a devil-may-care soap maker form an underground fight club that evolves into much more.",
                    Year = "1999",
                    Actors = new List<string>
                    {
                        "Brad Pitt",
                        "Edward Norton",
                        "Helena Bonham Carter"
                    },
                    Genres = new List<string>
                    {
                        "Drama"
                    }
                },
                new Movie
                {
                    Id = 2,
                    Title = "Inglourious Basterds",
                    Director = "Quentin Tarantino",
                    Synopsis = "In Nazi-occupied France during World War II, a plan to assassinate Nazi leaders by a group of Jewish U.S. soldiers coincides with a theatre owner's vengeful plans for the same.",
                    Year = "2009",
                    Actors =
                    {
                        "Brad Pitt",
                        "Diane Kruger",
                        "Eli Roth"
                    },
                    Genres = new List<string>
                    {
                        "Adventure",
                        "Drama",
                        "War"
                    }
                });
        }
    }
}
