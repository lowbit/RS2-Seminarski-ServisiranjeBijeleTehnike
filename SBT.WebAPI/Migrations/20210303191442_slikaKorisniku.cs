using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SBT.WebAPI.Migrations
{
    public partial class slikaKorisniku : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Slika",
                table: "Korisnici",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slika",
                table: "Korisnici");
        }
    }
}
