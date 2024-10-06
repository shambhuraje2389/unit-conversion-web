using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UnitConversion.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConversionHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Input = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Output = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SourceUnitId = table.Column<int>(type: "int", nullable: false),
                    TargetUnitId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversionHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConversionRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceUnitId = table.Column<int>(type: "int", nullable: false),
                    TargetUnitId = table.Column<int>(type: "int", nullable: false),
                    Formula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversionRates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ConversionRates",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Formula", "SourceUnitId", "TargetUnitId" },
                values: new object[,]
                {
                    { 1, null, null, "(inputVal*1000)", 1, 2 },
                    { 2, null, null, "(inputVal*100000)", 1, 3 },
                    { 3, null, null, "(inputVal/1.609)", 1, 4 },
                    { 4, null, null, "(inputVal*3281)", 1, 5 },
                    { 5, null, null, "(inputVal/39370)", 1, 6 },
                    { 6, null, null, "(inputVal/1000)", 2, 1 },
                    { 7, null, null, "(inputVal*100)", 2, 3 },
                    { 8, null, null, "(inputVal/1609)", 2, 4 },
                    { 9, null, null, "(inputVal*3.281)", 2, 5 },
                    { 10, null, null, "(inputVal*39.37)", 2, 6 },
                    { 11, null, null, "(inputVal/100000)", 3, 1 },
                    { 12, null, null, "(inputVal/100)", 3, 2 },
                    { 13, null, null, "(inputVal/160900)", 3, 4 },
                    { 14, null, null, "(inputVal/30.48)", 3, 5 },
                    { 15, null, null, "(inputVal/2.54)", 3, 6 },
                    { 16, null, null, "(inputVal*1.609)", 4, 1 },
                    { 17, null, null, "(inputVal*1609)", 4, 2 },
                    { 18, null, null, "(inputVal*160900)", 4, 3 },
                    { 19, null, null, "(inputVal*5280)", 4, 5 },
                    { 20, null, null, "(inputVal*63360)", 4, 6 },
                    { 21, null, null, "(inputVal/3281)", 5, 1 },
                    { 22, null, null, "(inputVal/3.281)", 5, 2 },
                    { 23, null, null, "(inputVal*30.48)", 5, 3 },
                    { 24, null, null, "(inputVal/5280)", 5, 4 },
                    { 25, null, null, "(inputVal*12)", 5, 6 },
                    { 26, null, null, "(inputVal/39370)", 6, 1 },
                    { 27, null, null, "(inputVal/39.37)", 6, 2 },
                    { 28, null, null, "(inputVal* 2.54)", 6, 3 },
                    { 29, null, null, "(inputVal/63360)", 6, 4 },
                    { 30, null, null, "(inputVal/12)", 6, 5 },
                    { 31, null, null, "(inputVal/1000)", 7, 8 },
                    { 32, null, null, "(inputVal*1000)", 7, 9 },
                    { 33, null, null, "(inputVal/453.6)", 7, 10 },
                    { 34, null, null, "(inputVal*1000)", 8, 7 },
                    { 35, null, null, "(inputVal*1e+6)", 8, 9 },
                    { 36, null, null, "(inputVal*2.205)", 8, 10 },
                    { 37, null, null, "(inputVal/1000)", 9, 7 },
                    { 38, null, null, "(inputVal/1e+6)", 9, 8 },
                    { 39, null, null, "(inputVal/453600)", 9, 10 },
                    { 40, null, null, "(inputVal*453.6)", 10, 7 },
                    { 41, null, null, "(inputVal/2.205)", 10, 8 },
                    { 42, null, null, "(inputVal*453600)", 10, 9 },
                    { 43, null, null, "(inputVal+ 273.15)", 11, 12 },
                    { 44, null, null, "((inputVal*9/5) + 32)", 11, 13 },
                    { 45, null, null, "(inputVal− 273.15)", 12, 11 },
                    { 46, null, null, "((inputVal− 273.15)*9/5) + 32)", 12, 13 },
                    { 47, null, null, "((inputVal-32)*5/9)", 13, 11 },
                    { 48, null, null, "((inputVal-32)*5/9 +273.15)", 13, 12 }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Name", "Type" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 10, 6, 13, 50, 32, 812, DateTimeKind.Local).AddTicks(1500), "Kilometer", 1 },
                    { 2, null, new DateTime(2024, 10, 6, 13, 50, 32, 812, DateTimeKind.Local).AddTicks(1513), "Meter", 1 },
                    { 3, null, new DateTime(2024, 10, 6, 13, 50, 32, 812, DateTimeKind.Local).AddTicks(1514), "Centimeter", 1 },
                    { 4, null, new DateTime(2024, 10, 6, 13, 50, 32, 812, DateTimeKind.Local).AddTicks(1515), "Mile", 1 },
                    { 5, null, new DateTime(2024, 10, 6, 13, 50, 32, 812, DateTimeKind.Local).AddTicks(1516), "Foot", 1 },
                    { 6, null, new DateTime(2024, 10, 6, 13, 50, 32, 812, DateTimeKind.Local).AddTicks(1517), "Inch", 1 },
                    { 7, null, new DateTime(2024, 10, 6, 13, 50, 32, 812, DateTimeKind.Local).AddTicks(1518), "Gram", 2 },
                    { 8, null, new DateTime(2024, 10, 6, 13, 50, 32, 812, DateTimeKind.Local).AddTicks(1519), "Kilogram", 2 },
                    { 9, null, new DateTime(2024, 10, 6, 13, 50, 32, 812, DateTimeKind.Local).AddTicks(1520), "Miligram", 2 },
                    { 10, null, new DateTime(2024, 10, 6, 13, 50, 32, 812, DateTimeKind.Local).AddTicks(1521), "Pound", 2 },
                    { 11, null, new DateTime(2024, 10, 6, 13, 50, 32, 812, DateTimeKind.Local).AddTicks(1522), "Celsius", 3 },
                    { 12, null, new DateTime(2024, 10, 6, 13, 50, 32, 812, DateTimeKind.Local).AddTicks(1523), "Kelvin", 3 },
                    { 13, null, new DateTime(2024, 10, 6, 13, 50, 32, 812, DateTimeKind.Local).AddTicks(1524), "Fahrenheit", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConversionHistory");

            migrationBuilder.DropTable(
                name: "ConversionRates");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
