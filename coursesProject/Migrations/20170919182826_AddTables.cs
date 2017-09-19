using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace coursesProject.Migrations
{
    public partial class AddTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagsRelation_Project_ProjectID",
                table: "TagsRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_TagsRelation_Tag_TagId",
                table: "TagsRelation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagsRelation",
                table: "TagsRelation");

            migrationBuilder.RenameTable(
                name: "TagsRelation",
                newName: "TagRelation");

            migrationBuilder.RenameIndex(
                name: "IX_TagsRelation_TagId",
                table: "TagRelation",
                newName: "IX_TagRelation_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_TagsRelation_ProjectID",
                table: "TagRelation",
                newName: "IX_TagRelation_ProjectID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagRelation",
                table: "TagRelation",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MedalRelation",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedalRelation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MedalRelation_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medal",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MedalRelationID = table.Column<int>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medal", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Medal_MedalRelation_MedalRelationID",
                        column: x => x.MedalRelationID,
                        principalTable: "MedalRelation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medal_MedalRelationID",
                table: "Medal",
                column: "MedalRelationID");

            migrationBuilder.CreateIndex(
                name: "IX_MedalRelation_UserID",
                table: "MedalRelation",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_TagRelation_Project_ProjectID",
                table: "TagRelation",
                column: "ProjectID",
                principalTable: "Project",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagRelation_Tag_TagId",
                table: "TagRelation",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagRelation_Project_ProjectID",
                table: "TagRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_TagRelation_Tag_TagId",
                table: "TagRelation");

            migrationBuilder.DropTable(
                name: "Medal");

            migrationBuilder.DropTable(
                name: "MedalRelation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagRelation",
                table: "TagRelation");

            migrationBuilder.RenameTable(
                name: "TagRelation",
                newName: "TagsRelation");

            migrationBuilder.RenameIndex(
                name: "IX_TagRelation_TagId",
                table: "TagsRelation",
                newName: "IX_TagsRelation_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_TagRelation_ProjectID",
                table: "TagsRelation",
                newName: "IX_TagsRelation_ProjectID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagsRelation",
                table: "TagsRelation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TagsRelation_Project_ProjectID",
                table: "TagsRelation",
                column: "ProjectID",
                principalTable: "Project",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagsRelation_Tag_TagId",
                table: "TagsRelation",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
