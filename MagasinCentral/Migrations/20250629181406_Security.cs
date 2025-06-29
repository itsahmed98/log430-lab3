using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MagasinCentral.Migrations
{
    /// <inheritdoc />
    public partial class Security : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Ventes",
                keyColumn: "VenteId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 6, 27, 18, 14, 5, 799, DateTimeKind.Utc).AddTicks(1004));

            migrationBuilder.UpdateData(
                table: "Ventes",
                keyColumn: "VenteId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2025, 6, 28, 18, 14, 5, 799, DateTimeKind.Utc).AddTicks(1013));

            migrationBuilder.UpdateData(
                table: "Ventes",
                keyColumn: "VenteId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2025, 6, 28, 18, 14, 5, 799, DateTimeKind.Utc).AddTicks(1014));

            migrationBuilder.UpdateData(
                table: "Ventes",
                keyColumn: "VenteId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2025, 6, 29, 18, 14, 5, 799, DateTimeKind.Utc).AddTicks(1015));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.UpdateData(
                table: "Ventes",
                keyColumn: "VenteId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 6, 5, 22, 23, 43, 23, DateTimeKind.Utc).AddTicks(561));

            migrationBuilder.UpdateData(
                table: "Ventes",
                keyColumn: "VenteId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2025, 6, 6, 22, 23, 43, 23, DateTimeKind.Utc).AddTicks(568));

            migrationBuilder.UpdateData(
                table: "Ventes",
                keyColumn: "VenteId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2025, 6, 6, 22, 23, 43, 23, DateTimeKind.Utc).AddTicks(569));

            migrationBuilder.UpdateData(
                table: "Ventes",
                keyColumn: "VenteId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2025, 6, 7, 22, 23, 43, 23, DateTimeKind.Utc).AddTicks(570));
        }
    }
}
