using Microsoft.EntityFrameworkCore.Migrations;

namespace IntellProdLifeCycleMS.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IntelliegentWorks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Subtitle = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    DOI = table.Column<int>(type: "INTEGER", nullable: false),
                    Year = table.Column<string>(type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    GRINTI = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    Organization = table.Column<string>(type: "TEXT", nullable: true),
                    Level = table.Column<int>(type: "INTEGER", nullable: true),
                    Publisher = table.Column<string>(type: "TEXT", nullable: true),
                    Edition = table.Column<string>(type: "TEXT", nullable: true),
                    UDK = table.Column<string>(type: "TEXT", nullable: true),
                    PageCount = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntelliegentWorks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserID = table.Column<int>(type: "INTEGER", nullable: false),
                    FirstName = table.Column<int>(type: "INTEGER", nullable: false),
                    LastName = table.Column<int>(type: "INTEGER", nullable: false),
                    ShortFirstName = table.Column<int>(type: "INTEGER", nullable: false),
                    ShortPatronamicName = table.Column<int>(type: "INTEGER", nullable: false),
                    PatronamicName = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberInList = table.Column<int>(type: "INTEGER", nullable: false),
                    IntelliegentWorkId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authors_IntelliegentWorks_IntelliegentWorkId",
                        column: x => x.IntelliegentWorkId,
                        principalTable: "IntelliegentWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EducationalPrograms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EdProgramName = table.Column<string>(type: "TEXT", nullable: true),
                    BookId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationalPrograms_IntelliegentWorks_BookId",
                        column: x => x.BookId,
                        principalTable: "IntelliegentWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Indexations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Link = table.Column<int>(type: "INTEGER", nullable: false),
                    IntelliegentWorkId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indexations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Indexations_IntelliegentWorks_IntelliegentWorkId",
                        column: x => x.IntelliegentWorkId,
                        principalTable: "IntelliegentWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KeyWords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Word = table.Column<string>(type: "TEXT", nullable: true),
                    IntelliegentWorkId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyWords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KeyWords_IntelliegentWorks_IntelliegentWorkId",
                        column: x => x.IntelliegentWorkId,
                        principalTable: "IntelliegentWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_IntelliegentWorkId",
                table: "Authors",
                column: "IntelliegentWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalPrograms_BookId",
                table: "EducationalPrograms",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Indexations_IntelliegentWorkId",
                table: "Indexations",
                column: "IntelliegentWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_KeyWords_IntelliegentWorkId",
                table: "KeyWords",
                column: "IntelliegentWorkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "EducationalPrograms");

            migrationBuilder.DropTable(
                name: "Indexations");

            migrationBuilder.DropTable(
                name: "KeyWords");

            migrationBuilder.DropTable(
                name: "IntelliegentWorks");
        }
    }
}
