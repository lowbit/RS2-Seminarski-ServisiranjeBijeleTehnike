using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SBT.WebAPI.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UredjajiKategorija",
                table: "UredjajiKategorija");

            migrationBuilder.DropIndex(
                name: "IX_UredjajiKategorija_UredjajId",
                table: "UredjajiKategorija");

            migrationBuilder.DropColumn(
                name: "UredjajiKategorijaId",
                table: "UredjajiKategorija");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UredjajiKategorija",
                table: "UredjajiKategorija",
                columns: new[] { "UredjajId", "KategorijaId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UredjajiKategorija",
                table: "UredjajiKategorija");

            migrationBuilder.AddColumn<int>(
                name: "UredjajiKategorijaId",
                table: "UredjajiKategorija",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UredjajiKategorija",
                table: "UredjajiKategorija",
                column: "UredjajiKategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_UredjajiKategorija_UredjajId",
                table: "UredjajiKategorija",
                column: "UredjajId");
        }
    }
}
