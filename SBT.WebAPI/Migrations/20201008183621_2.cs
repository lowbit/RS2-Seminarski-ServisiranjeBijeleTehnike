using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SBT.WebAPI.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Cijena",
                table: "Servisi",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Opis",
                table: "Servisi",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Servisi",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZahtjevId",
                table: "Servisi",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Kategorije",
                columns: table => new
                {
                    KategorijaId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorije", x => x.KategorijaId);
                });

            migrationBuilder.CreateTable(
                name: "Proizvodjaci",
                columns: table => new
                {
                    ProizvodjacId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvodjaci", x => x.ProizvodjacId);
                });

            migrationBuilder.CreateTable(
                name: "TipDostave",
                columns: table => new
                {
                    TipDostaveId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipDostave", x => x.TipDostaveId);
                });

            migrationBuilder.CreateTable(
                name: "TipPlacanja",
                columns: table => new
                {
                    TipPlacanjaId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipPlacanja", x => x.TipPlacanjaId);
                });

            migrationBuilder.CreateTable(
                name: "Uredjaji",
                columns: table => new
                {
                    UredjajId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    KategorijaId = table.Column<int>(nullable: false),
                    ProizvodjacId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uredjaji", x => x.UredjajId);
                    table.ForeignKey(
                        name: "FK_Uredjaji_Kategorije_KategorijaId",
                        column: x => x.KategorijaId,
                        principalTable: "Kategorije",
                        principalColumn: "KategorijaId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Uredjaji_Proizvodjaci_ProizvodjacId",
                        column: x => x.ProizvodjacId,
                        principalTable: "Proizvodjaci",
                        principalColumn: "ProizvodjacId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SlikeUredjaja",
                columns: table => new
                {
                    SlikaUredjajaId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    path = table.Column<string>(nullable: true),
                    UredjajId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlikeUredjaja", x => x.SlikaUredjajaId);
                    table.ForeignKey(
                        name: "FK_SlikeUredjaja_Uredjaji_UredjajId",
                        column: x => x.UredjajId,
                        principalTable: "Uredjaji",
                        principalColumn: "UredjajId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Zahtjevi",
                columns: table => new
                {
                    ZahtjevId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Napomena = table.Column<string>(nullable: true),
                    DatumKreiranja = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    UredjajId = table.Column<int>(nullable: false),
                    TipPlacanjaId = table.Column<int>(nullable: false),
                    TipDostaveId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zahtjevi", x => x.ZahtjevId);
                    table.ForeignKey(
                        name: "FK_Zahtjevi_TipDostave_TipDostaveId",
                        column: x => x.TipDostaveId,
                        principalTable: "TipDostave",
                        principalColumn: "TipDostaveId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Zahtjevi_TipPlacanja_TipPlacanjaId",
                        column: x => x.TipPlacanjaId,
                        principalTable: "TipPlacanja",
                        principalColumn: "TipPlacanjaId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Zahtjevi_Uredjaji_UredjajId",
                        column: x => x.UredjajId,
                        principalTable: "Uredjaji",
                        principalColumn: "UredjajId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servisi_ZahtjevId",
                table: "Servisi",
                column: "ZahtjevId");

            migrationBuilder.CreateIndex(
                name: "IX_SlikeUredjaja_UredjajId",
                table: "SlikeUredjaja",
                column: "UredjajId");

            migrationBuilder.CreateIndex(
                name: "IX_Uredjaji_KategorijaId",
                table: "Uredjaji",
                column: "KategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Uredjaji_ProizvodjacId",
                table: "Uredjaji",
                column: "ProizvodjacId");

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
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servisi_Zahtjevi_ZahtjevId",
                table: "Servisi");

            migrationBuilder.DropTable(
                name: "SlikeUredjaja");

            migrationBuilder.DropTable(
                name: "Zahtjevi");

            migrationBuilder.DropTable(
                name: "TipDostave");

            migrationBuilder.DropTable(
                name: "TipPlacanja");

            migrationBuilder.DropTable(
                name: "Uredjaji");

            migrationBuilder.DropTable(
                name: "Kategorije");

            migrationBuilder.DropTable(
                name: "Proizvodjaci");

            migrationBuilder.DropIndex(
                name: "IX_Servisi_ZahtjevId",
                table: "Servisi");

            migrationBuilder.DropColumn(
                name: "Cijena",
                table: "Servisi");

            migrationBuilder.DropColumn(
                name: "Opis",
                table: "Servisi");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Servisi");

            migrationBuilder.DropColumn(
                name: "ZahtjevId",
                table: "Servisi");
        }
    }
}
