using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace coursesProject.Migrations
{
    public partial class ForIndexProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MinDescription",
                table: "Project",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinDescription",
                table: "Project");
        }
    }
}
