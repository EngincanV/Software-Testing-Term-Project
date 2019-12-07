using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuestionAnswer.DataAccess.Migrations
{
    public partial class Initializer3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Stats",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Stats",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
