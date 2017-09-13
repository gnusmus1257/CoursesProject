using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace coursesProject.Migrations
{
    public partial class UpdateTables1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Project",
                newName: "EndDate");

            migrationBuilder.AddColumn<bool>(
                name: "IsBan",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CollectMoney",
                table: "Project",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfRigister",
                table: "Project",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBan",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CollectMoney",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "DateOfRigister",
                table: "Project");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Project",
                newName: "Date");
        }
    }
}
