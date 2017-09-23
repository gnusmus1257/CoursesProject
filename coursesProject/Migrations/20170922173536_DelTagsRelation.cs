using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace coursesProject.Migrations
{
    public partial class DelTagsRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagRelation");

            migrationBuilder.AddColumn<int>(
                name: "ProjectID",
                table: "Tag",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tag_ProjectID",
                table: "Tag",
                column: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Project_ProjectID",
                table: "Tag",
                column: "ProjectID",
                principalTable: "Project",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Project_ProjectID",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_Tag_ProjectID",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "ProjectID",
                table: "Tag");

            migrationBuilder.CreateTable(
                name: "TagRelation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectID = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagRelation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagRelation_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Project",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagRelation_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TagRelation_ProjectID",
                table: "TagRelation",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_TagRelation_TagId",
                table: "TagRelation",
                column: "TagId");
        }
    }
}
