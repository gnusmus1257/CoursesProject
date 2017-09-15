using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace coursesProject.Migrations
{
    public partial class ForCreateProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MinDescription",
                table: "Project",
                newName: "ShortDescription");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShortDescription",
                table: "Project",
                newName: "MinDescription");
        }
    }
}
