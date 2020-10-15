using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SBT.WebAPI.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kategorije_Uredjaji_UredjajId",
                table: "Kategorije");

            migrationBuilder.DropIndex(
                name: "IX_Kategorije_UredjajId",
                table: "Kategorije");

            migrationBuilder.DropColumn(
                name: "UredjajId",
                table: "Kategorije");

            migrationBuilder.CreateTable(
                name: "UredjajiKategorija",
                columns: table => new
                {
                    UredjajiKategorijaId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UredjajId = table.Column<int>(nullable: false),
                    KategorijaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UredjajiKategorija", x => x.UredjajiKategorijaId);
                    table.ForeignKey(
                        name: "FK_UredjajiKategorija_Kategorije_KategorijaId",
                        column: x => x.KategorijaId,
                        principalTable: "Kategorije",
                        principalColumn: "KategorijaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UredjajiKategorija_Uredjaji_UredjajId",
                        column: x => x.UredjajId,
                        principalTable: "Uredjaji",
                        principalColumn: "UredjajId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UredjajiKategorija_KategorijaId",
                table: "UredjajiKategorija",
                column: "KategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_UredjajiKategorija_UredjajId",
                table: "UredjajiKategorija",
                column: "UredjajId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UredjajiKategorija");

            migrationBuilder.AddColumn<int>(
                name: "UredjajId",
                table: "Kategorije",
                type: "integer",
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
    }
}
