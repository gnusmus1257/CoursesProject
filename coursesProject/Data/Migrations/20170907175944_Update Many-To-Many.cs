using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace coursesProject.Data.Migrations
{
    public partial class UpdateManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_User_UserID",
                table: "Comment");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "TagRelation");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Project");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Tag",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Tag",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Comment",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Comment",
                newName: "AuthorID");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Comment",
                newName: "Context");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Comment",
                newName: "DateCreate");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_UserID",
                table: "Comment",
                newName: "IX_Comment_AuthorID");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Project",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Raiting",
                table: "Project",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TagsRelation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectID = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagsRelation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagsRelation_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Project",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagsRelation_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_CategoryId",
                table: "Project",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TagsRelation_ProjectID",
                table: "TagsRelation",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_TagsRelation_TagId",
                table: "TagsRelation",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_User_AuthorID",
                table: "Comment",
                column: "AuthorID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Category_CategoryId",
                table: "Project",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_User_AuthorID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Category_CategoryId",
                table: "Project");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "TagsRelation");

            migrationBuilder.DropIndex(
                name: "IX_Project_CategoryId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Raiting",
                table: "Project");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tag",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tag",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comment",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "DateCreate",
                table: "Comment",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "Context",
                table: "Comment",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "AuthorID",
                table: "Comment",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_AuthorID",
                table: "Comment",
                newName: "IX_Comment_UserID");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Project",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: true),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rating_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Project",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rating_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TagRelation",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectID = table.Column<int>(nullable: false),
                    TagID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagRelation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TagRelation_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Project",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagRelation_Tag_TagID",
                        column: x => x.TagID,
                        principalTable: "Tag",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rating_ProjectID",
                table: "Rating",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_UserID",
                table: "Rating",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_TagRelation_ProjectID",
                table: "TagRelation",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_TagRelation_TagID",
                table: "TagRelation",
                column: "TagID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_User_UserID",
                table: "Comment",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
