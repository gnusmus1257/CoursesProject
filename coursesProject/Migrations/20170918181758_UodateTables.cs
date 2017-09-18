using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace coursesProject.Migrations
{
    public partial class UodateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Category_CategoryId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_CategoryId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Project");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginDate",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ProjectCount",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Project",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastLoginDate",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ProjectCount",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Project");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Project",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Project_CategoryId",
                table: "Project",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Category_CategoryId",
                table: "Project",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
