using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Module.Catalog.Infrastructure.Persistence.Migrations
{
    public partial class InitialCreateSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Catalog");

            migrationBuilder.CreateTable(
                name: "Movies",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Synopsis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Actors = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genres = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Movies",
                columns: new[] { "Id", "Actors", "Director", "Genres", "Synopsis", "Title", "Year" },
                values: new object[] { 1, "[\"Brad Pitt\",\"Edward Norton\",\"Helena Bonham Carter\"]", "David Fincher", "[\"Drama\"]", "An insomniac office worker and a devil-may-care soap maker form an underground fight club that evolves into much more.", "Fight Club", "1999" });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Movies",
                columns: new[] { "Id", "Actors", "Director", "Genres", "Synopsis", "Title", "Year" },
                values: new object[] { 2, "[\"Brad Pitt\",\"Diane Kruger\",\"Eli Roth\"]", "Quentin Tarantino", "[\"Adventure\",\"Drama\",\"War\"]", "In Nazi-occupied France during World War II, a plan to assassinate Nazi leaders by a group of Jewish U.S. soldiers coincides with a theatre owner's vengeful plans for the same.", "Inglourious Basterds", "2009" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies",
                schema: "Catalog");
        }
    }
}
