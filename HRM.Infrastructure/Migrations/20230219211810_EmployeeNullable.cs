using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_EmployeeRole_EmployeeRoleId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_EmployeeStatus_EmployeeStatusId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_EmployeeType_EmployeeTypeId",
                table: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeTypeId",
                table: "Employee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeStatusId",
                table: "Employee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeRoleId",
                table: "Employee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_EmployeeRole_EmployeeRoleId",
                table: "Employee",
                column: "EmployeeRoleId",
                principalTable: "EmployeeRole",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_EmployeeStatus_EmployeeStatusId",
                table: "Employee",
                column: "EmployeeStatusId",
                principalTable: "EmployeeStatus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_EmployeeType_EmployeeTypeId",
                table: "Employee",
                column: "EmployeeTypeId",
                principalTable: "EmployeeType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_EmployeeRole_EmployeeRoleId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_EmployeeStatus_EmployeeStatusId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_EmployeeType_EmployeeTypeId",
                table: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeTypeId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeStatusId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeRoleId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_EmployeeRole_EmployeeRoleId",
                table: "Employee",
                column: "EmployeeRoleId",
                principalTable: "EmployeeRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_EmployeeStatus_EmployeeStatusId",
                table: "Employee",
                column: "EmployeeStatusId",
                principalTable: "EmployeeStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_EmployeeType_EmployeeTypeId",
                table: "Employee",
                column: "EmployeeTypeId",
                principalTable: "EmployeeType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
