using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkwaylabsExercise2.Migrations
{
    public partial class ParkwaylabsExercise2DataDevTeamDBContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Developer",
                columns: table => new
                {
                    DeveloperId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developer", x => x.DeveloperId);
                });

            migrationBuilder.CreateTable(
                name: "TechLead",
                columns: table => new
                {
                    TechLeadId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechLead", x => x.TechLeadId);
                });

            migrationBuilder.CreateTable(
                name: "Technology",
                columns: table => new
                {
                    TechnologyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technology", x => x.TechnologyId);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperTechLead",
                columns: table => new
                {
                    DeveloperId = table.Column<int>(nullable: false),
                    TechLeadId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperTechLead", x => new { x.DeveloperId, x.TechLeadId });
                    table.ForeignKey(
                        name: "FK_DeveloperTechLead_Developer_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developer",
                        principalColumn: "DeveloperId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperTechLead_TechLead_TechLeadId",
                        column: x => x.TechLeadId,
                        principalTable: "TechLead",
                        principalColumn: "TechLeadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperTechnology",
                columns: table => new
                {
                    DeveloperId = table.Column<int>(nullable: false),
                    TechnologyId = table.Column<int>(nullable: false),
                    ExpLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperTechnology", x => new { x.DeveloperId, x.TechnologyId });
                    table.ForeignKey(
                        name: "FK_DeveloperTechnology_Developer_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developer",
                        principalColumn: "DeveloperId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperTechnology_Technology_TechnologyId",
                        column: x => x.TechnologyId,
                        principalTable: "Technology",
                        principalColumn: "TechnologyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TechLeadTechnology",
                columns: table => new
                {
                    TechLeadId = table.Column<int>(nullable: false),
                    TechnologyId = table.Column<int>(nullable: false),
                    ExpLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechLeadTechnology", x => new { x.TechLeadId, x.TechnologyId });
                    table.ForeignKey(
                        name: "FK_TechLeadTechnology_TechLead_TechLeadId",
                        column: x => x.TechLeadId,
                        principalTable: "TechLead",
                        principalColumn: "TechLeadId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TechLeadTechnology_Technology_TechnologyId",
                        column: x => x.TechnologyId,
                        principalTable: "Technology",
                        principalColumn: "TechnologyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperTechLead_TechLeadId",
                table: "DeveloperTechLead",
                column: "TechLeadId");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperTechnology_TechnologyId",
                table: "DeveloperTechnology",
                column: "TechnologyId");

            migrationBuilder.CreateIndex(
                name: "IX_TechLeadTechnology_TechnologyId",
                table: "TechLeadTechnology",
                column: "TechnologyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeveloperTechLead");

            migrationBuilder.DropTable(
                name: "DeveloperTechnology");

            migrationBuilder.DropTable(
                name: "TechLeadTechnology");

            migrationBuilder.DropTable(
                name: "Developer");

            migrationBuilder.DropTable(
                name: "TechLead");

            migrationBuilder.DropTable(
                name: "Technology");
        }
    }
}
