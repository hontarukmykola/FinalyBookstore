using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinalyBookstore.Migrations
{
    /// <inheritdoc />
    public partial class addInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "heir",
                table: "Book",
                newName: "Heir");

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "LastName", "Name", "SurName" },
                values: new object[,]
                {
                    { 1, "Nikolayevich", "Lev", "Tolstoy" },
                    { 2, "Afanasievich", "Mikhail", "Bulgakov" },
                    { 3, "Katherine", "Joan", "Rowling" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "historical novel" },
                    { 2, "fantasy novel" },
                    { 3, "fantasy" }
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Russian Herald" },
                    { 2, "Moscow" },
                    { 3, "Bloomsbury" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "CostPrice", "GenreId", "Heir", "Name", "Pages", "Price", "PublisherId", "Year" },
                values: new object[,]
                {
                    { 1, 1, 200m, 1, true, "war and peace", 1225, 500m, 1, 1867 },
                    { 2, 2, 180m, 2, false, "The Master and Margarita", 384, 280m, 2, 1967 },
                    { 3, 3, 120m, 3, false, "Harry Potter and the Philosopher's Stone", 320, 200m, 3, 1997 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "Heir",
                table: "Book",
                newName: "heir");
        }
    }
}
