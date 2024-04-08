using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InprocessWebApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, "Ciencia Ficción", new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dune: Parte 2" },
                    { 2, "Drama", new DateTime(2014, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "El clan de hierro" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
