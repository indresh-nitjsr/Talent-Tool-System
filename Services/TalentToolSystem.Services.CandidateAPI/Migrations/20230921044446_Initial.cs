using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TalentToolSystem.Services.CandidateAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    CandidateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillSet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfExperience = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CTC = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ECTC = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NoticePeriod = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.CandidateId);
                });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "CandidateId", "CTC", "CandidateName", "CurrentCompany", "ECTC", "Email", "EmployeeID", "Location", "Mobile", "NoticePeriod", "SkillSet", "Status", "YearOfExperience" },
                values: new object[,]
                {
                    { 1, 10m, "Indresh Kumar Maurya", "Nexturn", 10m, "indresh@gmail.com", 101, "Mirzapur", "7823637281", 10, "C++,.Net,Sql Server", "Selected", 1 },
                    { 2, 10m, "Shobhit Kumar Singh", "Nexturn", 10m, "shobhit@gmail.com", 101, "Patna", "7823637281", 10, "C++,.Net,Sql Server", "Selected", 1 },
                    { 3, 10m, "Abuzar Nasim", "Nexturn", 10m, "abuzar@gmail.com", 101, "Ranchi", "7823637281", 10, "C++,.Net,Sql Server", "Selected", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidates");
        }
    }
}
