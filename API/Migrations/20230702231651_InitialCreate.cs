using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name2 = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<float>(type: "REAL", nullable: false),
                    Deposit = table.Column<float>(type: "REAL", nullable: false),
                    VolymInml = table.Column<float>(type: "REAL", nullable: false),
                    PricePerLiter = table.Column<float>(type: "REAL", nullable: false),
                    SalesStart = table.Column<float>(type: "REAL", nullable: false),
                    Discontinued = table.Column<bool>(type: "INTEGER", nullable: false),
                    ProductGroup = table.Column<string>(type: "TEXT", nullable: true),
                    Stype = table.Column<string>(type: "TEXT", nullable: true),
                    Style = table.Column<string>(type: "TEXT", nullable: true),
                    Packaging = table.Column<string>(type: "TEXT", nullable: true),
                    SealType = table.Column<string>(type: "TEXT", nullable: true),
                    Origin = table.Column<string>(type: "TEXT", nullable: true),
                    OriginCountryName = table.Column<string>(type: "TEXT", nullable: true),
                    ProducerId = table.Column<int>(type: "INTEGER", nullable: true),
                    Supplier = table.Column<string>(type: "TEXT", nullable: true),
                    Vintage = table.Column<string>(type: "TEXT", nullable: true),
                    AlcoholContent = table.Column<string>(type: "TEXT", nullable: true),
                    AssortmentCode = table.Column<string>(type: "TEXT", nullable: true),
                    AssortmentText = table.Column<string>(type: "TEXT", nullable: true),
                    Organic = table.Column<bool>(type: "INTEGER", nullable: false),
                    Ethical = table.Column<bool>(type: "INTEGER", nullable: false),
                    Kosher = table.Column<bool>(type: "INTEGER", nullable: false),
                    RawMaterialsDescription = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Producers_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProducerId",
                table: "Products",
                column: "ProducerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Producers");
        }
    }
}
