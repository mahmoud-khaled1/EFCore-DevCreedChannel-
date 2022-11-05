using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Seeding Data
            migrationBuilder.Sql("insert into Employees Values('Ali Ahmed')");
         

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //Remove Seeding Data
            migrationBuilder.Sql("Delete from Employees where Name='Ali Ahmed'");
        }
    }
}
