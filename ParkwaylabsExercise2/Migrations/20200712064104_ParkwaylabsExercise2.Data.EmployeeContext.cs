using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkwaylabsExercise2.Migrations
{
    public partial class ParkwaylabsExercise2DataEmployeeContext : Migration
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
                name: "Developer_TechLead",
                columns: table => new
                {
                    DeveloperId = table.Column<int>(nullable: false),
                    TechLeadId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developer_TechLead", x => new { x.DeveloperId, x.TechLeadId });
                    table.ForeignKey(
                        name: "FK_Developer_TechLead_Developer_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developer",
                        principalColumn: "DeveloperId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Developer_TechLead_TechLead_TechLeadId",
                        column: x => x.TechLeadId,
                        principalTable: "TechLead",
                        principalColumn: "TechLeadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Developer_Technology",
                columns: table => new
                {
                    DeveloperId = table.Column<int>(nullable: false),
                    TechnologyId = table.Column<int>(nullable: false),
                    ExpLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developer_Technology", x => new { x.DeveloperId, x.TechnologyId });
                    table.ForeignKey(
                        name: "FK_Developer_Technology_Developer_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developer",
                        principalColumn: "DeveloperId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Developer_Technology_Technology_TechnologyId",
                        column: x => x.TechnologyId,
                        principalTable: "Technology",
                        principalColumn: "TechnologyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TechLead_Technology",
                columns: table => new
                {
                    TechLeadId = table.Column<int>(nullable: false),
                    TechnologyId = table.Column<int>(nullable: false),
                    ExpLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechLead_Technology", x => new { x.TechLeadId, x.TechnologyId });
                    table.ForeignKey(
                        name: "FK_TechLead_Technology_TechLead_TechLeadId",
                        column: x => x.TechLeadId,
                        principalTable: "TechLead",
                        principalColumn: "TechLeadId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TechLead_Technology_Technology_TechnologyId",
                        column: x => x.TechnologyId,
                        principalTable: "Technology",
                        principalColumn: "TechnologyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Developer_TechLead_TechLeadId",
                table: "Developer_TechLead",
                column: "TechLeadId");

            migrationBuilder.CreateIndex(
                name: "IX_Developer_Technology_TechnologyId",
                table: "Developer_Technology",
                column: "TechnologyId");

            migrationBuilder.CreateIndex(
                name: "IX_TechLead_Technology_TechnologyId",
                table: "TechLead_Technology",
                column: "TechnologyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Developer_TechLead");

            migrationBuilder.DropTable(
                name: "Developer_Technology");

            migrationBuilder.DropTable(
                name: "TechLead_Technology");

            migrationBuilder.DropTable(
                name: "Developer");

            migrationBuilder.DropTable(
                name: "TechLead");

            migrationBuilder.DropTable(
                name: "Technology");
        }
    }
}
