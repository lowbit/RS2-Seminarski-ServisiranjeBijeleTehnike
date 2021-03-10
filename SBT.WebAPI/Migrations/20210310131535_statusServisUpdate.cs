using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SBT.WebAPI.Migrations
{
    public partial class statusServisUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrenutniStatus",
                table: "StanjeServisa");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Servisi");

            migrationBuilder.AddColumn<int>(
                name: "StatusServisaId",
                table: "StanjeServisa",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusServisaId",
                table: "Servisi",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StatusServisa",
                columns: table => new
                {
                    StatusServisaId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusServisa", x => x.StatusServisaId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StanjeServisa_StatusServisaId",
                table: "StanjeServisa",
                column: "StatusServisaId");

            migrationBuilder.CreateIndex(
                name: "IX_Servisi_StatusServisaId",
                table: "Servisi",
                column: "StatusServisaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Servisi_StatusServisa_StatusServisaId",
                table: "Servisi",
                column: "StatusServisaId",
                principalTable: "StatusServisa",
                principalColumn: "StatusServisaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StanjeServisa_StatusServisa_StatusServisaId",
                table: "StanjeServisa",
                column: "StatusServisaId",
                principalTable: "StatusServisa",
                principalColumn: "StatusServisaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servisi_StatusServisa_StatusServisaId",
                table: "Servisi");

            migrationBuilder.DropForeignKey(
                name: "FK_StanjeServisa_StatusServisa_StatusServisaId",
                table: "StanjeServisa");

            migrationBuilder.DropTable(
                name: "StatusServisa");

            migrationBuilder.DropIndex(
                name: "IX_StanjeServisa_StatusServisaId",
                table: "StanjeServisa");

            migrationBuilder.DropIndex(
                name: "IX_Servisi_StatusServisaId",
                table: "Servisi");

            migrationBuilder.DropColumn(
                name: "StatusServisaId",
                table: "StanjeServisa");

            migrationBuilder.DropColumn(
                name: "StatusServisaId",
                table: "Servisi");

            migrationBuilder.AddColumn<string>(
                name: "TrenutniStatus",
                table: "StanjeServisa",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Servisi",
                type: "text",
                nullable: true);
        }
    }
}
