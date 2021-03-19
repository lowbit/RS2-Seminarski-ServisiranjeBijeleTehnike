using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SBT.WebAPI.Migrations
{
    public partial class pictureBlob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UredjajiKategorija");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "SlikeUredjaja");

            migrationBuilder.AddColumn<byte[]>(
                name: "Slika",
                table: "SlikeUredjaja",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Uredjaji_KategorijaId",
                table: "Uredjaji",
                column: "KategorijaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Uredjaji_Kategorije_KategorijaId",
                table: "Uredjaji",
                column: "KategorijaId",
                principalTable: "Kategorije",
                principalColumn: "KategorijaId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uredjaji_Kategorije_KategorijaId",
                table: "Uredjaji");

            migrationBuilder.DropIndex(
                name: "IX_Uredjaji_KategorijaId",
                table: "Uredjaji");

            migrationBuilder.DropColumn(
                name: "Slika",
                table: "SlikeUredjaja");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "SlikeUredjaja",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UredjajiKategorija",
                columns: table => new
                {
                    UredjajId = table.Column<int>(type: "integer", nullable: false),
                    KategorijaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UredjajiKategorija", x => new { x.UredjajId, x.KategorijaId });
                    table.ForeignKey(
                        name: "FK_UredjajiKategorija_Kategorije_KategorijaId",
                        column: x => x.KategorijaId,
                        principalTable: "Kategorije",
                        principalColumn: "KategorijaId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UredjajiKategorija_Uredjaji_UredjajId",
                        column: x => x.UredjajId,
                        principalTable: "Uredjaji",
                        principalColumn: "UredjajId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UredjajiKategorija_KategorijaId",
                table: "UredjajiKategorija",
                column: "KategorijaId");
        }
    }
}
