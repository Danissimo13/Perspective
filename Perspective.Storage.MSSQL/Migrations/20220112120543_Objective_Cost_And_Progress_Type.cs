using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Perspective.Storage.MSSQL.Migrations
{
    public partial class Objective_Cost_And_Progress_Type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Progress",
                table: "Objective",
                type: "DECIMAL(3,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "Objective",
                type: "MONEY",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Progress",
                table: "Objective",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(3,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "Objective",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "MONEY",
                oldNullable: true);
        }
    }
}
