using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kuari.TodoApp.Repository.Migrations
{
    public partial class SeedDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ToDos",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "Id", "Content", "IsCompleted" },
                values: new object[] { 1, "Angular 15 yeniliklerine bakılacak", false });

            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "Id", "Content", "IsCompleted" },
                values: new object[] { 2, "Asp.Net Core 6.0 WebAPI with ANGULAR M.Y TreversallApp geliştirilecek", false });

            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "Id", "Content", "IsCompleted" },
                values: new object[] { 3, "Asp.NET Core 6.0 WebAPI with Angular SbrWebApp geliştirilecek", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ToDos",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");
        }
    }
}
