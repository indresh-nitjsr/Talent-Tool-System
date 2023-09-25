using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TalentToolSystem.Services.DemandAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MaxBudget",
                table: "demands",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "demands",
                keyColumn: "DemandId",
                keyValue: 1,
                column: "MaxBudget",
                value: 10);

            migrationBuilder.UpdateData(
                table: "demands",
                keyColumn: "DemandId",
                keyValue: 2,
                column: "MaxBudget",
                value: 10);

            migrationBuilder.UpdateData(
                table: "demands",
                keyColumn: "DemandId",
                keyValue: 3,
                column: "MaxBudget",
                value: 10);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "MaxBudget",
                table: "demands",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "demands",
                keyColumn: "DemandId",
                keyValue: 1,
                column: "MaxBudget",
                value: 10.0);

            migrationBuilder.UpdateData(
                table: "demands",
                keyColumn: "DemandId",
                keyValue: 2,
                column: "MaxBudget",
                value: 10.0);

            migrationBuilder.UpdateData(
                table: "demands",
                keyColumn: "DemandId",
                keyValue: 3,
                column: "MaxBudget",
                value: 10.0);
        }
    }
}
