using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LSS.Data.Migrations
{
    public partial class Validations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDate",
                table: "Assignments",
                nullable: false,
                defaultValue: new DateTime(2018, 1, 2, 18, 25, 0, 603, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 12, 23, 17, 40, 52, 642, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_Students_FirstName_MiddleName_LastName",
                table: "Students",
                columns: new[] { "FirstName", "MiddleName", "LastName" });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Name",
                table: "Courses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_Name",
                table: "Assignments",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_FirstName_MiddleName_LastName",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Courses_Name",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_Name",
                table: "Assignments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDate",
                table: "Assignments",
                nullable: false,
                defaultValue: new DateTime(2017, 12, 23, 17, 40, 52, 642, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 1, 2, 18, 25, 0, 603, DateTimeKind.Local));
        }
    }
}
