using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SBT.WebAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorije",
                columns: table => new
                {
                    KategorijaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorije", x => x.KategorijaId);
                });

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    KorisnikId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    KorisnickoIme = table.Column<string>(nullable: true),
                    LozinkaHash = table.Column<string>(nullable: true),
                    LozinkaSalt = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: true),
                    Slika = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.KorisnikId);
                });

            migrationBuilder.CreateTable(
                name: "Proizvodjaci",
                columns: table => new
                {
                    ProizvodjacId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvodjaci", x => x.ProizvodjacId);
                });

            migrationBuilder.CreateTable(
                name: "StatusServisa",
                columns: table => new
                {
                    StatusServisaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusServisa", x => x.StatusServisaId);
                });

            migrationBuilder.CreateTable(
                name: "TipDostave",
                columns: table => new
                {
                    TipDostaveId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipPlacanja", x => x.TipPlacanjaId);
                });

            migrationBuilder.CreateTable(
                name: "Uloge",
                columns: table => new
                {
                    UlogaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloge", x => x.UlogaId);
                });

            migrationBuilder.CreateTable(
                name: "Uredjaji",
                columns: table => new
                {
                    UredjajId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Uredjaji_Proizvodjaci_ProizvodjacId",
                        column: x => x.ProizvodjacId,
                        principalTable: "Proizvodjaci",
                        principalColumn: "ProizvodjacId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KorisniciUloge",
                columns: table => new
                {
                    KorisnikUlogaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(nullable: false),
                    UlogaId = table.Column<int>(nullable: false),
                    DatumIzmjene = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisniciUloge", x => x.KorisnikUlogaId);
                    table.ForeignKey(
                        name: "FK_KorisniciUloge_Korisnici",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KorisniciUloge_Uloge",
                        column: x => x.UlogaId,
                        principalTable: "Uloge",
                        principalColumn: "UlogaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Servisi",
                columns: table => new
                {
                    ServisId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opis = table.Column<string>(nullable: true),
                    DatumServisa = table.Column<DateTime>(nullable: false),
                    Cijena = table.Column<double>(nullable: false),
                    OcjenaServisa = table.Column<int>(nullable: false),
                    StatusServisaId = table.Column<int>(nullable: false),
                    ServiserId = table.Column<int>(nullable: false),
                    KlijentId = table.Column<int>(nullable: false),
                    UredjajId = table.Column<int>(nullable: false),
                    TipPlacanjaId = table.Column<int>(nullable: false),
                    TipDostaveId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servisi", x => x.ServisId);
                    table.ForeignKey(
                        name: "FK_Servisi_Korisnici_KlijentId",
                        column: x => x.KlijentId,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servisi_Korisnici_ServiserId",
                        column: x => x.ServiserId,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servisi_StatusServisa_StatusServisaId",
                        column: x => x.StatusServisaId,
                        principalTable: "StatusServisa",
                        principalColumn: "StatusServisaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servisi_TipDostave_TipDostaveId",
                        column: x => x.TipDostaveId,
                        principalTable: "TipDostave",
                        principalColumn: "TipDostaveId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servisi_TipPlacanja_TipPlacanjaId",
                        column: x => x.TipPlacanjaId,
                        principalTable: "TipPlacanja",
                        principalColumn: "TipPlacanjaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servisi_Uredjaji_UredjajId",
                        column: x => x.UredjajId,
                        principalTable: "Uredjaji",
                        principalColumn: "UredjajId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SlikeUredjaja",
                columns: table => new
                {
                    SlikaUredjajaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slika = table.Column<byte[]>(nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StanjeServisa",
                columns: table => new
                {
                    StanjeServisaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Napomena = table.Column<string>(nullable: true),
                    StatusServisaId = table.Column<int>(nullable: false),
                    ServisId = table.Column<int>(nullable: false),
                    Azurirano = table.Column<DateTime>(nullable: false)
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
                    table.ForeignKey(
                        name: "FK_StanjeServisa_StatusServisa_StatusServisaId",
                        column: x => x.StatusServisaId,
                        principalTable: "StatusServisa",
                        principalColumn: "StatusServisaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KorisniciUloge_KorisnikId",
                table: "KorisniciUloge",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisniciUloge_UlogaId",
                table: "KorisniciUloge",
                column: "UlogaId");

            migrationBuilder.CreateIndex(
                name: "IX_Servisi_KlijentId",
                table: "Servisi",
                column: "KlijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Servisi_ServiserId",
                table: "Servisi",
                column: "ServiserId");

            migrationBuilder.CreateIndex(
                name: "IX_Servisi_StatusServisaId",
                table: "Servisi",
                column: "StatusServisaId");

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
                name: "IX_SlikeUredjaja_UredjajId",
                table: "SlikeUredjaja",
                column: "UredjajId");

            migrationBuilder.CreateIndex(
                name: "IX_StanjeServisa_ServisId",
                table: "StanjeServisa",
                column: "ServisId");

            migrationBuilder.CreateIndex(
                name: "IX_StanjeServisa_StatusServisaId",
                table: "StanjeServisa",
                column: "StatusServisaId");

            migrationBuilder.CreateIndex(
                name: "IX_Uredjaji_KategorijaId",
                table: "Uredjaji",
                column: "KategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Uredjaji_ProizvodjacId",
                table: "Uredjaji",
                column: "ProizvodjacId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KorisniciUloge");

            migrationBuilder.DropTable(
                name: "SlikeUredjaja");

            migrationBuilder.DropTable(
                name: "StanjeServisa");

            migrationBuilder.DropTable(
                name: "Uloge");

            migrationBuilder.DropTable(
                name: "Servisi");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "StatusServisa");

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
        }
    }
}
