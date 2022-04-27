﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Module.Catalog.Infrastructure.Persistence;

#nullable disable

namespace Module.Catalog.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(CatalogDbContext))]
    [Migration("20220427200601_AddSeedMovies")]
    partial class AddSeedMovies
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Catalog")
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Module.Catalog.Core.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Actors")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Synopsis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Movies", "Catalog");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Actors = "[\"Brad Pitt\",\"Edward Norton\",\"Helena Bonham Carter\"]",
                            Director = "David Fincher",
                            Genres = "[\"Drama\"]",
                            Synopsis = "An insomniac office worker and a devil-may-care soap maker form an underground fight club that evolves into much more.",
                            Title = "Fight Club",
                            Year = "1999"
                        },
                        new
                        {
                            Id = 2,
                            Actors = "[\"Brad Pitt\",\"Diane Kruger\",\"Eli Roth\"]",
                            Director = "Quentin Tarantino",
                            Genres = "[\"Adventure\",\"Drama\",\"War\"]",
                            Synopsis = "In Nazi-occupied France during World War II, a plan to assassinate Nazi leaders by a group of Jewish U.S. soldiers coincides with a theatre owner's vengeful plans for the same.",
                            Title = "Inglourious Basterds",
                            Year = "2009"
                        },
                        new
                        {
                            Id = 3,
                            Actors = "[\"Ansel Elgort\",\"Jon Bernthal\",\"Jon Hamm\"]",
                            Director = "Edgar Wright",
                            Genres = "[\"Action\",\"Crime\",\"Drama\"]",
                            Synopsis = "After being coerced into working for a crime boss, a young getaway driver finds himself taking part in a heist doomed to fail.",
                            Title = "Baby Driver",
                            Year = "2017"
                        },
                        new
                        {
                            Id = 4,
                            Actors = "[\"Jason Statham\",\"Amy Smart\",\"Carlos Sanz\"]",
                            Director = "Mark Neveldine",
                            Genres = "[\"Action\",\"Crime\",\"Thriller\"]",
                            Synopsis = "Professional assassin Chev Chelios learns his rival has injected him with a poison that will kill him if his heart rate drops.",
                            Title = "Crank",
                            Year = "2006"
                        },
                        new
                        {
                            Id = 5,
                            Actors = "[\"Jason Statham\",\"Brad Pitt\",\"Stephen Graham\"]",
                            Director = "Guy Ritchie",
                            Genres = "[\"Comedy\",\"Crime\"]",
                            Synopsis = "Unscrupulous boxing promoters, violent bookmakers, a Russian gangster, incompetent amateur robbers and supposedly Jewish jewelers fight to track down a priceless stolen diamond.",
                            Title = "Snatch",
                            Year = "2000"
                        },
                        new
                        {
                            Id = 6,
                            Actors = "[\"Marlon Brando\",\"Al Pacino\",\"James Caan\"]",
                            Director = "Francis Ford Coppola",
                            Genres = "[\"Crime\",\"Drama\"]",
                            Synopsis = "The aging patriarch of an organized crime dynasty in postwar New York City transfers control of his clandestine empire to his reluctant youngest son.",
                            Title = "The Godfather",
                            Year = "1972"
                        },
                        new
                        {
                            Id = 7,
                            Actors = "[\"David Lee Smith\",\"Tony Todd\",\"John Billingsley\"]",
                            Director = "Richard Schenkman",
                            Genres = "[\"Drama\",\"Fantasy\",\"Mystery\"]",
                            Synopsis = "An impromptu goodbye party for Professor John Oldman becomes a mysterious interrogation after the retiring scholar reveals to his colleagues he has a longer and stranger past than they can imagine.",
                            Title = "The Man from Earth",
                            Year = "2007"
                        },
                        new
                        {
                            Id = 8,
                            Actors = "[\"Franka Potente\",\"Matt Damon\",\"Chris Cooper\"]",
                            Director = "Doug Liman",
                            Genres = "[\"Action\",\"Mystery\",\"Thriller\"]",
                            Synopsis = "A man is picked up by a fishing boat, bullet-riddled and suffering from amnesia, before racing to elude assassins and attempting to regain his memory.",
                            Title = "The Bourne Identity",
                            Year = "2002"
                        },
                        new
                        {
                            Id = 9,
                            Actors = "[\"Adam Sandler\",\"Kate Beckinsale\",\"Christopher Walken\"]",
                            Director = "Frank Coraci",
                            Genres = "[\"Comedy\",\"Drama\",\"Fantasy\"]",
                            Synopsis = "A workaholic architect finds a universal remote that allows him to fast-forward and rewind to different parts of his life. Complications arise when the remote starts to overrule his choices.",
                            Title = "Click",
                            Year = "2006"
                        },
                        new
                        {
                            Id = 10,
                            Actors = "[\"Leonardo DiCaprio\",\"Tom Hanks\",\"Christopher Walken\"]",
                            Director = "Steven Spielberg",
                            Genres = "[\"Biography\",\"Crime\",\"Drama\"]",
                            Synopsis = "Barely 21 yet, Frank is a skilled forger who has passed as a doctor, lawyer and pilot. FBI agent Carl becomes obsessed with tracking down the con man, who only revels in the pursuit.",
                            Title = "Catch Me If You Can",
                            Year = "2002"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
