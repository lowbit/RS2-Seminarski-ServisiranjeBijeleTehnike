using Microsoft.EntityFrameworkCore.Migrations;

namespace SBT.WebAPI.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uredjaji_Kategorije_KategorijaId",
                table: "Uredjaji");

            migrationBuilder.DropIndex(
                name: "IX_Uredjaji_KategorijaId",
                table: "Uredjaji");

            migrationBuilder.DropColumn(
                name: "KategorijaId",
                table: "Uredjaji");

            migrationBuilder.RenameColumn(
                name: "path",
                table: "SlikeUredjaja",
                newName: "Path");

            migrationBuilder.AddColumn<int>(
                name: "Ocjena",
                table: "Servisi",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UredjajId",
                table: "Kategorije",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kategorije_UredjajId",
                table: "Kategorije",
                column: "UredjajId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kategorije_Uredjaji_UredjajId",
                table: "Kategorije",
                column: "UredjajId",
                principalTable: "Uredjaji",
                principalColumn: "UredjajId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kategorije_Uredjaji_UredjajId",
                table: "Kategorije");

            migrationBuilder.DropIndex(
                name: "IX_Kategorije_UredjajId",
                table: "Kategorije");

            migrationBuilder.DropColumn(
                name: "Ocjena",
                table: "Servisi");

            migrationBuilder.DropColumn(
                name: "UredjajId",
                table: "Kategorije");

            migrationBuilder.RenameColumn(
                name: "Path",
                table: "SlikeUredjaja",
                newName: "path");

            migrationBuilder.AddColumn<int>(
                name: "KategorijaId",
                table: "Uredjaji",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
