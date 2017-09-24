using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace coursesProject.Data.Migrations
{
    public partial class Topic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_New_Project_ProjectID",
                table: "New");

            migrationBuilder.DropPrimaryKey(
                name: "PK_New",
                table: "New");

            migrationBuilder.RenameTable(
                name: "New",
                newName: "Topic");

            migrationBuilder.RenameIndex(
                name: "IX_New_ProjectID",
                table: "Topic",
                newName: "IX_Topic_ProjectID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topic",
                table: "Topic",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_Project_ProjectID",
                table: "Topic",
                column: "ProjectID",
                principalTable: "Project",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topic_Project_ProjectID",
                table: "Topic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topic",
                table: "Topic");

            migrationBuilder.RenameTable(
                name: "Topic",
                newName: "New");

            migrationBuilder.RenameIndex(
                name: "IX_Topic_ProjectID",
                table: "New",
                newName: "IX_New_ProjectID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_New",
                table: "New",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_New_Project_ProjectID",
                table: "New",
                column: "ProjectID",
                principalTable: "Project",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
