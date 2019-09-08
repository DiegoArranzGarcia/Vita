using Microsoft.EntityFrameworkCore.Migrations;

namespace Vita.Persistance.Sql.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Color", "Name" },
                values: new object[,]
                {
                    { 1L, "skyblue", "Cooking" },
                    { 2L, "crimson", "Sports" },
                    { 3L, "darkorange", "VideoGames" },
                    { 4L, "lightslategray", "Travel" },
                    { 5L, "deeppink", "Study" },
                    { 6L, "springgreen", "TV Series" },
                    { 7L, "turquoise", "Movies" },
                    { 8L, "darkslateblue", "Books" },
                    { 9L, "limegreen", "Music" },
                    { 10L, "lightseagreen", "Places" },
                    { 11L, "darkcyan", "Podcasts" },
                    { 12L, "dodgerblue", "Bar & Clubs" },
                    { 13L, "tomato", "Restaurants" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13L);
        }
    }
}
