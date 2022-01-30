using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Perspective.Storage.MSSQL.Migrations
{
    public partial class User_PasswordHash_Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "User",
                newName: "PasswordHash");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "User",
                newName: "Password");
        }
    }
}
