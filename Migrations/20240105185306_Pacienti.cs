using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proiect.Migrations
{
    public partial class Pacienti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Numar_telefon",
                table: "Pacient",
                newName: "Prenume");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNasterii",
                table: "Pacient",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumarTelefon",
                table: "Pacient",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNasterii",
                table: "Pacient");

            migrationBuilder.DropColumn(
                name: "NumarTelefon",
                table: "Pacient");

            migrationBuilder.RenameColumn(
                name: "Prenume",
                table: "Pacient",
                newName: "Numar_telefon");
        }
    }
}
