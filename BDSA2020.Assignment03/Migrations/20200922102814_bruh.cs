using Microsoft.EntityFrameworkCore.Migrations;

namespace BDSA2020.Assignment03.Migrations
{
    public partial class bruh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Tasks_TaskId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_TaskId",
                table: "Tags");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Tags");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[] { 1, "john@email.dk", "John" });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_TaskId",
                table: "Tags",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Tasks_TaskId",
                table: "Tags",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
