using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace clinicaveterinariaBackEnd.Migrations
{
    public partial class contraseniaUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "usuarios",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "usuarios",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "usuarios");
        }
    }
}
