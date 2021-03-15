using Microsoft.EntityFrameworkCore.Migrations;

namespace SBT.WebAPI.Migrations
{
    public partial class fixedStanjeServisa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StanjeServisa_Servisi_ServisId",
                table: "StanjeServisa");

            migrationBuilder.AlterColumn<int>(
                name: "ServisId",
                table: "StanjeServisa",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StanjeServisa_Servisi_ServisId",
                table: "StanjeServisa",
                column: "ServisId",
                principalTable: "Servisi",
                principalColumn: "ServisId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StanjeServisa_Servisi_ServisId",
                table: "StanjeServisa");

            migrationBuilder.AlterColumn<int>(
                name: "ServisId",
                table: "StanjeServisa",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_StanjeServisa_Servisi_ServisId",
                table: "StanjeServisa",
                column: "ServisId",
                principalTable: "Servisi",
                principalColumn: "ServisId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
