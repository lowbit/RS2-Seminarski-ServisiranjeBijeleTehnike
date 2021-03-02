using Microsoft.EntityFrameworkCore.Migrations;

namespace SBT.WebAPI.Migrations
{
    public partial class _6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KategorijaId",
                table: "Uredjaji",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KategorijaId",
                table: "Uredjaji");
        }
    }
}
