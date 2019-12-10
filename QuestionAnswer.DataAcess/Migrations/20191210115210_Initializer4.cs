using Microsoft.EntityFrameworkCore.Migrations;

namespace QuestionAnswer.DataAccess.Migrations
{
    public partial class Initializer4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsVisited",
                table: "UserQuestions",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVisited",
                table: "UserQuestions");
        }
    }
}
