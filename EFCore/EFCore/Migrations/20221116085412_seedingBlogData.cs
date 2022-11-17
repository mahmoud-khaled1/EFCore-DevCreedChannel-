using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    public partial class seedingBlogData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "CreateTime", "Rating", "Url" },
                values: new object[] { 8, new DateTime(2021, 6, 23, 7, 21, 11, 0, DateTimeKind.Unspecified), 7, "www.google.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
