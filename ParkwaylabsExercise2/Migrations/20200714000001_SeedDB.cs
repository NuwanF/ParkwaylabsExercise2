using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkwaylabsExercise2.Migrations
{
    public partial class SeedDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Developer",
                columns: new[] { "DeveloperId", "Name" },
                values: new object[,]
                {
                    { 1, "Saman" },
                    { 2, "Ruwan" },
                    { 3, "Jehan" },
                    { 4, "Achini" },
                    { 5, "Suwan" },
                    { 6, "Ajith" }
                });

            migrationBuilder.InsertData(
                table: "TechLead",
                columns: new[] { "TechLeadId", "Name" },
                values: new object[,]
                {
                    { 1, "Aruna" },
                    { 2, "Hasith" },
                    { 3, "Amal" }
                });

            migrationBuilder.InsertData(
                table: "Technology",
                columns: new[] { "TechnologyId", "Name" },
                values: new object[,]
                {
                    { 1, "C#" },
                    { 2, "React" },
                    { 3, "JQuery" }
                });

            migrationBuilder.InsertData(
                table: "DeveloperTechLead",
                columns: new[] { "DeveloperId", "TechLeadId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 5, 1 },
                    { 4, 2 },
                    { 2, 2 },
                    { 6, 2 },
                    { 3, 3 },
                    { 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "DeveloperTechnology",
                columns: new[] { "DeveloperId", "TechnologyId", "ExpLevel" },
                values: new object[,]
                {
                    { 4, 2, 6 },
                    { 3, 2, 6 },
                    { 2, 2, 5 },
                    { 1, 2, 5 },
                    { 2, 3, 4 },
                    { 1, 3, 6 },
                    { 5, 2, 4 },
                    { 1, 1, 4 },
                    { 6, 2, 5 }
                });

            migrationBuilder.InsertData(
                table: "TechLeadTechnology",
                columns: new[] { "TechLeadId", "TechnologyId", "ExpLevel" },
                values: new object[,]
                {
                    { 2, 2, 6 },
                    { 3, 1, 4 },
                    { 2, 1, 5 },
                    { 1, 1, 4 },
                    { 2, 3, 5 },
                    { 3, 3, 6 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeveloperTechLead",
                keyColumns: new[] { "DeveloperId", "TechLeadId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "DeveloperTechLead",
                keyColumns: new[] { "DeveloperId", "TechLeadId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "DeveloperTechLead",
                keyColumns: new[] { "DeveloperId", "TechLeadId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "DeveloperTechLead",
                keyColumns: new[] { "DeveloperId", "TechLeadId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "DeveloperTechLead",
                keyColumns: new[] { "DeveloperId", "TechLeadId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "DeveloperTechLead",
                keyColumns: new[] { "DeveloperId", "TechLeadId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "DeveloperTechLead",
                keyColumns: new[] { "DeveloperId", "TechLeadId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "DeveloperTechnology",
                keyColumns: new[] { "DeveloperId", "TechnologyId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "DeveloperTechnology",
                keyColumns: new[] { "DeveloperId", "TechnologyId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "DeveloperTechnology",
                keyColumns: new[] { "DeveloperId", "TechnologyId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "DeveloperTechnology",
                keyColumns: new[] { "DeveloperId", "TechnologyId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "DeveloperTechnology",
                keyColumns: new[] { "DeveloperId", "TechnologyId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "DeveloperTechnology",
                keyColumns: new[] { "DeveloperId", "TechnologyId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "DeveloperTechnology",
                keyColumns: new[] { "DeveloperId", "TechnologyId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "DeveloperTechnology",
                keyColumns: new[] { "DeveloperId", "TechnologyId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "DeveloperTechnology",
                keyColumns: new[] { "DeveloperId", "TechnologyId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "TechLeadTechnology",
                keyColumns: new[] { "TechLeadId", "TechnologyId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "TechLeadTechnology",
                keyColumns: new[] { "TechLeadId", "TechnologyId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "TechLeadTechnology",
                keyColumns: new[] { "TechLeadId", "TechnologyId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "TechLeadTechnology",
                keyColumns: new[] { "TechLeadId", "TechnologyId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "TechLeadTechnology",
                keyColumns: new[] { "TechLeadId", "TechnologyId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "TechLeadTechnology",
                keyColumns: new[] { "TechLeadId", "TechnologyId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Developer",
                keyColumn: "DeveloperId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Developer",
                keyColumn: "DeveloperId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Developer",
                keyColumn: "DeveloperId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Developer",
                keyColumn: "DeveloperId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Developer",
                keyColumn: "DeveloperId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Developer",
                keyColumn: "DeveloperId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TechLead",
                keyColumn: "TechLeadId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TechLead",
                keyColumn: "TechLeadId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TechLead",
                keyColumn: "TechLeadId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Technology",
                keyColumn: "TechnologyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Technology",
                keyColumn: "TechnologyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Technology",
                keyColumn: "TechnologyId",
                keyValue: 3);
        }
    }
}
