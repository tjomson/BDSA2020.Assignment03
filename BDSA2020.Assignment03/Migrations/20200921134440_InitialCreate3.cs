using Microsoft.EntityFrameworkCore.Migrations;

namespace BDSA2020.Assignment03.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskTags",
                columns: table => new
                {
                    TagId = table.Column<int>(nullable: false),
                    TaskId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskTags");
        }
    }
}
