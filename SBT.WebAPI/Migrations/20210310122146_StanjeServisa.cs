using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SBT.WebAPI.Migrations
{
    public partial class StanjeServisa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servisi_Zahtjevi_ZahtjevId",
                table: "Servisi");

            migrationBuilder.DropTable(
                name: "Zahtjevi");

            migrationBuilder.DropIndex(
                name: "IX_Servisi_ZahtjevId",
                table: "Servisi");

            migrationBuilder.DropColumn(
                name: "Ocjena",
                table: "Servisi");

            migrationBuilder.DropColumn(
                name: "ZahtjevId",
                table: "Servisi");

            migrationBuilder.AddColumn<int>(
                name: "KlijentId",
                table: "Servisi",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OcjenaServisa",
                table: "Servisi",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServiserId",
                table: "Servisi",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipDostaveId",
                table: "Servisi",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipPlacanjaId",
                table: "Servisi",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UredjajId",
                table: "Servisi",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StanjeServisa",
                columns: table => new
                {
                    StanjeServisaId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Napomena = table.Column<string>(nullable: true),
                    TrenutniStatus = table.Column<string>(nullable: true),
                    Azurirano = table.Column<DateTime>(nullable: false),
                    ServisId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StanjeServisa", x => x.StanjeServisaId);
                    table.ForeignKey(
                        name: "FK_StanjeServisa_Servisi_ServisId",
                        column: x => x.ServisId,
                        principalTable: "Servisi",
                        principalColumn: "ServisId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servisi_KlijentId",
                table: "Servisi",
                column: "KlijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Servisi_ServiserId",
                table: "Servisi",
                column: "ServiserId");

            migrationBuilder.CreateIndex(
                name: "IX_Servisi_TipDostaveId",
                table: "Servisi",
                column: "TipDostaveId");

            migrationBuilder.CreateIndex(
                name: "IX_Servisi_TipPlacanjaId",
                table: "Servisi",
                column: "TipPlacanjaId");

            migrationBuilder.CreateIndex(
                name: "IX_Servisi_UredjajId",
                table: "Servisi",
                column: "UredjajId");

            migrationBuilder.CreateIndex(
                name: "IX_StanjeServisa_ServisId",
                table: "StanjeServisa",
                column: "ServisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Servisi_Korisnici_KlijentId",
                table: "Servisi",
                column: "KlijentId",
                principalTable: "Korisnici",
                principalColumn: "KorisnikId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servisi_Korisnici_ServiserId",
                table: "Servisi",
                column: "ServiserId",
                principalTable: "Korisnici",
                principalColumn: "KorisnikId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servisi_TipDostave_TipDostaveId",
                table: "Servisi",
                column: "TipDostaveId",
                principalTable: "TipDostave",
                principalColumn: "TipDostaveId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servisi_TipPlacanja_TipPlacanjaId",
                table: "Servisi",
                column: "TipPlacanjaId",
                principalTable: "TipPlacanja",
                principalColumn: "TipPlacanjaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servisi_Uredjaji_UredjajId",
                table: "Servisi",
                column: "UredjajId",
                principalTable: "Uredjaji",
                principalColumn: "UredjajId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servisi_Korisnici_KlijentId",
                table: "Servisi");

            migrationBuilder.DropForeignKey(
                name: "FK_Servisi_Korisnici_ServiserId",
                table: "Servisi");

            migrationBuilder.DropForeignKey(
                name: "FK_Servisi_TipDostave_TipDostaveId",
                table: "Servisi");

            migrationBuilder.DropForeignKey(
                name: "FK_Servisi_TipPlacanja_TipPlacanjaId",
                table: "Servisi");

            migrationBuilder.DropForeignKey(
                name: "FK_Servisi_Uredjaji_UredjajId",
                table: "Servisi");

            migrationBuilder.DropTable(
                name: "StanjeServisa");

            migrationBuilder.DropIndex(
                name: "IX_Servisi_KlijentId",
                table: "Servisi");

            migrationBuilder.DropIndex(
                name: "IX_Servisi_ServiserId",
                table: "Servisi");

            migrationBuilder.DropIndex(
                name: "IX_Servisi_TipDostaveId",
                table: "Servisi");

            migrationBuilder.DropIndex(
                name: "IX_Servisi_TipPlacanjaId",
                table: "Servisi");

            migrationBuilder.DropIndex(
                name: "IX_Servisi_UredjajId",
                table: "Servisi");

            migrationBuilder.DropColumn(
                name: "KlijentId",
                table: "Servisi");

            migrationBuilder.DropColumn(
                name: "OcjenaServisa",
                table: "Servisi");

            migrationBuilder.DropColumn(
                name: "ServiserId",
                table: "Servisi");

            migrationBuilder.DropColumn(
                name: "TipDostaveId",
                table: "Servisi");

            migrationBuilder.DropColumn(
                name: "TipPlacanjaId",
                table: "Servisi");

            migrationBuilder.DropColumn(
                name: "UredjajId",
                table: "Servisi");

            migrationBuilder.AddColumn<int>(
                name: "Ocjena",
                table: "Servisi",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ZahtjevId",
                table: "Servisi",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Zahtjevi",
                columns: table => new
                {
                    ZahtjevId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DatumKreiranja = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Napomena = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    TipDostaveId = table.Column<int>(type: "integer", nullable: false),
                    TipPlacanjaId = table.Column<int>(type: "integer", nullable: false),
                    UredjajId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zahtjevi", x => x.ZahtjevId);
                    table.ForeignKey(
                        name: "FK_Zahtjevi_TipDostave_TipDostaveId",
                        column: x => x.TipDostaveId,
                        principalTable: "TipDostave",
                        principalColumn: "TipDostaveId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zahtjevi_TipPlacanja_TipPlacanjaId",
                        column: x => x.TipPlacanjaId,
                        principalTable: "TipPlacanja",
                        principalColumn: "TipPlacanjaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zahtjevi_Uredjaji_UredjajId",
                        column: x => x.UredjajId,
                        principalTable: "Uredjaji",
                        principalColumn: "UredjajId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servisi_ZahtjevId",
                table: "Servisi",
                column: "ZahtjevId");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjevi_TipDostaveId",
                table: "Zahtjevi",
                column: "TipDostaveId");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjevi_TipPlacanjaId",
                table: "Zahtjevi",
                column: "TipPlacanjaId");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjevi_UredjajId",
                table: "Zahtjevi",
                column: "UredjajId");

            migrationBuilder.AddForeignKey(
                name: "FK_Servisi_Zahtjevi_ZahtjevId",
                table: "Servisi",
                column: "ZahtjevId",
                principalTable: "Zahtjevi",
                principalColumn: "ZahtjevId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
