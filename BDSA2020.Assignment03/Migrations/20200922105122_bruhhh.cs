using Microsoft.EntityFrameworkCore.Migrations;

namespace BDSA2020.Assignment03.Migrations
{
    public partial class bruhhh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskTags",
                table: "TaskTags",
                columns: new[] { "TaskId", "TagId" });

            migrationBuilder.InsertData(
                table: "TaskTags",
                columns: new[] { "TaskId", "TagId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "TaskTags",
                columns: new[] { "TaskId", "TagId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "TaskTags",
                columns: new[] { "TaskId", "TagId" },
                values: new object[] { 2, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskTags",
                table: "TaskTags");

            migrationBuilder.DeleteData(
                table: "TaskTags",
                keyColumns: new[] { "TaskId", "TagId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "TaskTags",
                keyColumns: new[] { "TaskId", "TagId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "TaskTags",
                keyColumns: new[] { "TaskId", "TagId" },
                keyValues: new object[] { 2, 3 });
        }
    }
}
