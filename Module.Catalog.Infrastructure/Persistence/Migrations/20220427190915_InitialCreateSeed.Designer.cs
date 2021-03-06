// <auto-generated />
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
    [Migration("20220427190915_InitialCreateSeed")]
    partial class InitialCreateSeed
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
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
