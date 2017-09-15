using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace coursesProject.Migrations
{
    public partial class ScanPasporta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommentForVerified",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonalInfoForVerified",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentForVerified",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PersonalInfoForVerified",
                table: "User");
        }
    }
}
