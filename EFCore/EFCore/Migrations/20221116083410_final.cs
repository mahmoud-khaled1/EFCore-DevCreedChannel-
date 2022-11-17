using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<string>(
            //    name: "DisplayName",
            //    table: "Authors",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldComputedColumnSql: "[FName] + [LName]");

            migrationBuilder.CreateTable(
                name: "BlogImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogForeignKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogImage_Blogs_BlogForeignKey",
                        column: x => x.BlogForeignKey,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "PostTag",
                columns: table => new
                {
                    PostsId = table.Column<int>(type: "int", nullable: false),
                    TagsTagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTag", x => new { x.PostsId, x.TagsTagId });
                    table.ForeignKey(
                        name: "FK_PostTag_Post_PostsId",
                        column: x => x.PostsId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTag_Tags_TagsTagId",
                        column: x => x.TagsTagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogImage_BlogForeignKey",
                table: "BlogImage",
                column: "BlogForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostTag_TagsTagId",
                table: "PostTag",
                column: "TagsTagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogImage");

            migrationBuilder.DropTable(
                name: "PostTag");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "[FName] + [LName]",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
