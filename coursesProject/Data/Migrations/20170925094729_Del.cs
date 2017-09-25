using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace coursesProject.Data.Migrations
{
    public partial class Del : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Project_ProjectID",
                table: "Rating");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectID",
                table: "Rating",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Project_ProjectID",
                table: "Rating",
                column: "ProjectID",
                principalTable: "Project",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Project_ProjectID",
                table: "Rating");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectID",
                table: "Rating",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Project_ProjectID",
                table: "Rating",
                column: "ProjectID",
                principalTable: "Project",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
