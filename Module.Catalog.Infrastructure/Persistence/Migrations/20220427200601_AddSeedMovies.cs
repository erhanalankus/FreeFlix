using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Module.Catalog.Infrastructure.Persistence.Migrations
{
    public partial class AddSeedMovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Movies",
                columns: new[] { "Id", "Actors", "Director", "Genres", "Synopsis", "Title", "Year" },
                values: new object[,]
                {
                    { 3, "[\"Ansel Elgort\",\"Jon Bernthal\",\"Jon Hamm\"]", "Edgar Wright", "[\"Action\",\"Crime\",\"Drama\"]", "After being coerced into working for a crime boss, a young getaway driver finds himself taking part in a heist doomed to fail.", "Baby Driver", "2017" },
                    { 4, "[\"Jason Statham\",\"Amy Smart\",\"Carlos Sanz\"]", "Mark Neveldine", "[\"Action\",\"Crime\",\"Thriller\"]", "Professional assassin Chev Chelios learns his rival has injected him with a poison that will kill him if his heart rate drops.", "Crank", "2006" },
                    { 5, "[\"Jason Statham\",\"Brad Pitt\",\"Stephen Graham\"]", "Guy Ritchie", "[\"Comedy\",\"Crime\"]", "Unscrupulous boxing promoters, violent bookmakers, a Russian gangster, incompetent amateur robbers and supposedly Jewish jewelers fight to track down a priceless stolen diamond.", "Snatch", "2000" },
                    { 6, "[\"Marlon Brando\",\"Al Pacino\",\"James Caan\"]", "Francis Ford Coppola", "[\"Crime\",\"Drama\"]", "The aging patriarch of an organized crime dynasty in postwar New York City transfers control of his clandestine empire to his reluctant youngest son.", "The Godfather", "1972" },
                    { 7, "[\"David Lee Smith\",\"Tony Todd\",\"John Billingsley\"]", "Richard Schenkman", "[\"Drama\",\"Fantasy\",\"Mystery\"]", "An impromptu goodbye party for Professor John Oldman becomes a mysterious interrogation after the retiring scholar reveals to his colleagues he has a longer and stranger past than they can imagine.", "The Man from Earth", "2007" },
                    { 8, "[\"Franka Potente\",\"Matt Damon\",\"Chris Cooper\"]", "Doug Liman", "[\"Action\",\"Mystery\",\"Thriller\"]", "A man is picked up by a fishing boat, bullet-riddled and suffering from amnesia, before racing to elude assassins and attempting to regain his memory.", "The Bourne Identity", "2002" },
                    { 9, "[\"Adam Sandler\",\"Kate Beckinsale\",\"Christopher Walken\"]", "Frank Coraci", "[\"Comedy\",\"Drama\",\"Fantasy\"]", "A workaholic architect finds a universal remote that allows him to fast-forward and rewind to different parts of his life. Complications arise when the remote starts to overrule his choices.", "Click", "2006" },
                    { 10, "[\"Leonardo DiCaprio\",\"Tom Hanks\",\"Christopher Walken\"]", "Steven Spielberg", "[\"Biography\",\"Crime\",\"Drama\"]", "Barely 21 yet, Frank is a skilled forger who has passed as a doctor, lawyer and pilot. FBI agent Carl becomes obsessed with tracking down the con man, who only revels in the pursuit.", "Catch Me If You Can", "2002" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Catalog",
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Catalog",
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Catalog",
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Catalog",
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Catalog",
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "Catalog",
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "Catalog",
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "Catalog",
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
