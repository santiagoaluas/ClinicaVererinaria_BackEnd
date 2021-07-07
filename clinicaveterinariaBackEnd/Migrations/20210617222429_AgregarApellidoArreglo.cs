using Microsoft.EntityFrameworkCore.Migrations;

namespace clinicaveterinariaBackEnd.Migrations
{
    public partial class AgregarApellidoArreglo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "apellidoCliente",
                table: "cliente",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "apellidoCliente",
                table: "cliente");
        }
    }
}
