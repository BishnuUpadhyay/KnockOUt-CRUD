using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class changeentityname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HiredDate",
                table: "Employees",
                newName: "Hireddate");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Employees",
                newName: "Fullname");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Employees",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Hireddate",
                table: "Employees",
                newName: "HiredDate");

            migrationBuilder.RenameColumn(
                name: "Fullname",
                table: "Employees",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Employees",
                newName: "EmployeeId");
        }
    }
}
