using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TalentToolSystem.Services.DemandAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "demands",
                columns: table => new
                {
                    DemandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DemandName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Account_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpenPosition = table.Column<int>(type: "int", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: true),
                    MaxBudget = table.Column<double>(type: "float", nullable: false),
                    NoticePeriod = table.Column<int>(type: "int", nullable: false),
                    EmployeeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skills = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_demands", x => x.DemandId);
                });

            migrationBuilder.InsertData(
                table: "demands",
                columns: new[] { "DemandId", "Account_Name", "DemandName", "Email", "EmployeeType", "Experience", "Location", "Manager", "MaxBudget", "NoticePeriod", "OpenPosition", "Skills", "Status" },
                values: new object[,]
                {
                    { 1, "Amazon", "Python Developer", "nexturn@gmail.com", "FTE", 1, "Hyderabad", "Gunjan", 10.0, 2, 1, "C++,.Net,Sql Server", "Selected" },
                    { 2, "Amazon", "Java Developer", "nexturn@gmail.com", "FTE", 1, "Hyderabad", "Gunjan", 10.0, 2, 1, "C++,.Net,Sql Server", "Selected" },
                    { 3, "Amazon", ".Net Developer", "nexturn@gmail.com", "FTE", 1, "Hyderabad", "Gunjan", 10.0, 2, 1, "C++,.Net,Sql Server", "Selected" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "demands");
        }
    }
}
