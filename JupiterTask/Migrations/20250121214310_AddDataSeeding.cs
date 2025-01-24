using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JupiterTask.Migrations
{
    /// <inheritdoc />
    public partial class AddDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "Web development competition", "https://example.com/web-image.jpg", "Web" },
                    { 2, "Flutter development competition", "https://example.com/flutter-image.jpg", "Flutter" },
                    { 3, "Sumo robot competition", "https://example.com/sumo-image.jpg", "Sumo" },
                    { 4, "Line follower robot competition", "https://example.com/linefollower-image.jpg", "LineFollower" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "IsAdmin", "LastName", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "johndoe@example.com", "John", false, "Doe", "Password123", "123456789" },
                    { 2, "janedoe@example.com", "Jane", false, "Doe", "Password456", "987654321" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Team Alpha" },
                    { 2, 2, "Team Beta" },
                    { 3, 1, "Team Gamma" }
                });

            migrationBuilder.InsertData(
                table: "Scores",
                columns: new[] { "Id", "TeamId", "Value" },
                values: new object[,]
                {
                    { 1, 1, 85 },
                    { 2, 2, 90 },
                    { 3, 3, 75 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
