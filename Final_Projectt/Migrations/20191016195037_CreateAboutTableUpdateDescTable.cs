using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Projectt.Migrations
{
    public partial class CreateAboutTableUpdateDescTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Abouts",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 500);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Abouts",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 1000);
        }
    }
}
