using Microsoft.EntityFrameworkCore.Migrations;

namespace BDSA2020.Assignment03.Migrations
{
    public partial class testadduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Tasks");

            migrationBuilder.AddColumn<string>(
                name: "TaskState",
                table: "Tasks",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[] { 1, "john@email.dk", "John" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "TaskState",
                table: "Tasks");

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
