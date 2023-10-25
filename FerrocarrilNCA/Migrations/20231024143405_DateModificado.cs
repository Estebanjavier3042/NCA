using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FerrocarrilNCA.Migrations
{
    /// <inheritdoc />
    public partial class DateModificado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaDeLiquidacion",
                table: "Sueldos",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaDeLiquidacion",
                table: "Sueldos");
        }
    }
}
