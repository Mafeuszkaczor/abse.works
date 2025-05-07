using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace abse.works.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalSkills = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Localization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Period = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobOffers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfessionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_Professions_ProfessionId",
                        column: x => x.ProfessionId,
                        principalTable: "Professions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobOfferSkills",
                columns: table => new
                {
                    JobOfferId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOfferSkills", x => new { x.JobOfferId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_JobOfferSkills_JobOffers_JobOfferId",
                        column: x => x.JobOfferId,
                        principalTable: "JobOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobOfferSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_CountryId",
                table: "JobOffers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOfferSkills_SkillId",
                table: "JobOfferSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_ProfessionId",
                table: "Skills",
                column: "ProfessionId");

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Language" },
                values: new object[,]
                {
                    { 1, "Poland", "Polish" },
                    { 2, "Germany", "German" }
                }
            );

            migrationBuilder.InsertData(
                table: "Professions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Budownictwo i wykończenia" },
                    { 2, "Prace ziemne i landworkerzy" },
                    { 3, "Instalacje elektryczne i fotowoltaika" },
                    { 4, "Usuwanie azbestu i prace z PVC" },
                    { 5, "Mechanicy linii produkcyjnych" },
                    { 6, "Domy drewniane i modułowe" },
                    { 7, "Cięcie CNC" }
                }
            );

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Name", "ProfessionId" },
                values: new object[,]
                {
                    // Budownictwo i wykończenia (ID=1)
                    { 1, "Stolarz budowlany", 1 },
                    { 2, "Montaż płyt gipsowo-kartonowych", 1 },
                    { 3, "Układanie płytek ceramicznych", 1 },
        
                    // Prace ziemne (ID=2)
                    { 4, "Operator koparki", 2 },
                    { 5, "Wykonywanie wykopów", 2 },
                    { 6, "Obsługa walca drogowego", 2 },
        
                    // Elektryka i fotowoltaika (ID=3)
                    { 7, "Instalacje elektryczne", 3 },
                    { 8, "Montaż paneli fotowoltaicznych", 3 },
                    { 9, "Diagnostyka instalacji", 3 },
        
                    // Azbest i PVC (ID=4)
                    { 10, "Usuwanie azbestu", 4 },
                    { 11, "Montaż rur PVC", 4 },
                    { 12, "Hermetyzacja odpadów", 4 },
        
                    // Mechanicy (ID=5)
                    { 13, "Serwis linii produkcyjnych", 5 },
                    { 14, "Programowanie maszyn CNC", 5 },
                    { 15, "Diagnostyka układów hydraulicznych", 5 },
        
                    // Domy drewniane (ID=6)
                    { 16, "Montaż konstrukcji drewnianych", 6 },
                    { 17, "Izolacja termiczna", 6 },
                    { 18, "Prefabrykacja elementów", 6 },
        
                    // Cięcie CNC (ID=7)
                    { 19, "Obsługa frezarki CNC", 7 },
                    { 20, "Programowanie CAD/CAM", 7 },
                    { 21, "Cięcie sklejki", 7 }
                }
            );

            migrationBuilder.InsertData(
                table: "JobOffers",
                columns: new[] { "Id", "Position", "Description", "Duties", "AdditionalInfo", "AdditionalSkills", "Salary", "CountryId", "Localization", "Period", "StartDate" },
                values: new object[,]
                {
                    // Oferta 1: Budownictwo (Polska)
                    {
                        1,
                        "Stolarz budowlany",
                        "Poszukujemy stolarza do prac wykończeniowych w Warszawie.",
                        "Montaż schodów, układanie paneli.",
                        "Wymagane doświadczenie min. 2 lata.",
                        "Prawo jazdy kat. B",
                        "6500-8000 PLN",
                        1,
                        "Warszawa",
                        12,
                        new DateTime(2025, 6, 1)
                    },
        
                    // Oferta 2: Prace ziemne (Niemcy)
                    {
                        2,
                        "Operator koparki",
                        "Praca przy budowie autostrady w Berlinie.",
                        "Wykopy, niwelacja terenu.",
                        "Kwalifikacje UDT wymagane.",
                        "Znajomość niemieckiego B1",
                        "4000-5000 EUR",
                        2,
                        "Berlin",
                        6,
                        new DateTime(2025, 5, 15)
                    }
                });


            migrationBuilder.InsertData(
                table: "JobOfferSkills",
                columns: new[] { "JobOfferId", "SkillId" },
                values: new object[,]
                {
                    // Oferta 1 (Stolarz) wymaga umiejętności 1, 2, 3
                    { 1, 1 }, { 1, 2 }, { 1, 3 },
        
                    // Oferta 2 (Operator koparki) wymaga umiejętności 4, 5
                    { 2, 4 }, { 2, 5 }
                });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobOfferSkills");

            migrationBuilder.DropTable(
                name: "JobOffers");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Professions");
        }
    }
}
