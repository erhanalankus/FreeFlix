using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module.Catalog.Core.Entities;
using System.Text.Json;

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

            // ICollection<string> represents a mutable reference type. This means that a ValueComparer<T> is needed so that EF Core can track and detect changes correctly.
            builder.Property(m => m.Actors).HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null),
                new ValueComparer<ICollection<string>>(
                    (c1, c2) => c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => (ICollection<string>)c.ToList()));
            builder.Property(m => m.Genres).HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null),
                new ValueComparer<ICollection<string>>(
                    (c1, c2) => c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => (ICollection<string>)c.ToList()));

            builder.Property(m => m.Timestamp).IsRowVersion();

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
                    Actors = new List<string>
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
                },
                new Movie
                {
                    Id = 3,
                    Title = "Baby Driver",
                    Director = "Edgar Wright",
                    Synopsis = "After being coerced into working for a crime boss, a young getaway driver finds himself taking part in a heist doomed to fail.",
                    Year = "2017",
                    Actors = new List<string>
                    {
                        "Ansel Elgort",
                        "Jon Bernthal",
                        "Jon Hamm"
                    },
                    Genres = new List<string>
                    {
                        "Action",
                        "Crime",
                        "Drama"
                    }
                },
                new Movie
                {
                    Id = 4,
                    Title = "Crank",
                    Director = "Mark Neveldine",                    
                    Synopsis = "Professional assassin Chev Chelios learns his rival has injected him with a poison that will kill him if his heart rate drops.",
                    Year = "2006",
                    Actors = new List<string>
                    {
                        "Jason Statham",
                        "Amy Smart",
                        "Carlos Sanz"
                    },
                    Genres = new List<string>
                    {
                        "Action",
                        "Crime",
                        "Thriller"
                    }
                },
                new Movie
                {
                    Id = 5,
                    Title = "Snatch",
                    Director = "Guy Ritchie",
                    Synopsis = "Unscrupulous boxing promoters, violent bookmakers, a Russian gangster, incompetent amateur robbers and supposedly Jewish jewelers fight to track down a priceless stolen diamond.",
                    Year = "2000",
                    Actors = new List<string>
                    {
                        "Jason Statham",
                        "Brad Pitt",
                        "Stephen Graham"
                    },
                    Genres = new List<string>
                    {
                        "Comedy",
                        "Crime"
                    }
                },
                new Movie
                {
                    Id = 6,
                    Title = "The Godfather",
                    Director = "Francis Ford Coppola",
                    Synopsis = "The aging patriarch of an organized crime dynasty in postwar New York City transfers control of his clandestine empire to his reluctant youngest son.",
                    Year = "1972",
                    Actors = new List<string>
                    {
                        "Marlon Brando",
                        "Al Pacino",
                        "James Caan"
                    },
                    Genres = new List<string>
                    {
                        "Crime",
                        "Drama"
                    }
                },
                new Movie
                {
                    Id = 7,
                    Title = "The Man from Earth",
                    Director = "Richard Schenkman",
                    Synopsis = "An impromptu goodbye party for Professor John Oldman becomes a mysterious interrogation after the retiring scholar reveals to his colleagues he has a longer and stranger past than they can imagine.",
                    Year = "2007",
                    Actors = new List<string>
                    {
                        "David Lee Smith",
                        "Tony Todd",
                        "John Billingsley"
                    },
                    Genres = new List<string>
                    {
                        "Drama",
                        "Fantasy",
                        "Mystery"
                    }
                },
                new Movie
                {
                    Id = 8,
                    Title = "The Bourne Identity",
                    Director = "Doug Liman",
                    Synopsis = "A man is picked up by a fishing boat, bullet-riddled and suffering from amnesia, before racing to elude assassins and attempting to regain his memory.",
                    Year = "2002",
                    Actors = new List<string>
                    {
                        "Franka Potente",
                        "Matt Damon",
                        "Chris Cooper"
                    },
                    Genres = new List<string>
                    {
                        "Action",
                        "Mystery",
                        "Thriller"
                    }
                },
                new Movie
                {
                    Id = 9,
                    Title = "Click",
                    Director = "Frank Coraci",
                    Synopsis = "A workaholic architect finds a universal remote that allows him to fast-forward and rewind to different parts of his life. Complications arise when the remote starts to overrule his choices.",
                    Year = "2006",
                    Actors = new List<string>
                    {
                        "Adam Sandler",
                        "Kate Beckinsale",
                        "Christopher Walken"
                    },
                    Genres = new List<string>
                    {
                        "Comedy",
                        "Drama",
                        "Fantasy"
                    }
                },
                new Movie
                {
                    Id = 10,
                    Title = "Catch Me If You Can",
                    Director = "Steven Spielberg",
                    Synopsis = "Barely 21 yet, Frank is a skilled forger who has passed as a doctor, lawyer and pilot. FBI agent Carl becomes obsessed with tracking down the con man, who only revels in the pursuit.",
                    Year = "2002",
                    Actors = new List<string>
                    {
                        "Leonardo DiCaprio",
                        "Tom Hanks",
                        "Christopher Walken"
                    },
                    Genres = new List<string>
                    {
                        "Biography",
                        "Crime",
                        "Drama"
                    }
                }
                );
        }
    }
}
