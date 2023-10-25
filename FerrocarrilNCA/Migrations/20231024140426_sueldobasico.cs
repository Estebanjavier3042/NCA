using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FerrocarrilNCA.Migrations
{
    /// <inheritdoc />
    public partial class sueldobasico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SueldoBasico",
                table: "Categorias",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SueldoBasico",
                table: "Categorias");
        }
    }
}
