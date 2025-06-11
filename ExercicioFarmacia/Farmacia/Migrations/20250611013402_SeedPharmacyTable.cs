using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Farmacia.Migrations
{
    /// <inheritdoc />
    public partial class SeedPharmacyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pharmacies",
                columns: new[] { "Id", "Endereco", "Horario", "Nome" },
                values: new object[,]
                {
                    { 1, "Rua dos Abacaxis", "08:00 às 20:00", "Farmacia do Bairro" },
                    { 2, "Rua dos Abacates", "08:00 às 21:00", "Farmacia Leve mais" },
                    { 3, "Ameixas", "07:00 às 21:00", "Farmacia Amiga" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pharmacies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pharmacies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pharmacies",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
