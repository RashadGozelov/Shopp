using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Projectt.Migrations
{
    public partial class CreateProductMarkaCategoryReferencesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MarkaCategoryId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_MarkaCategoryId",
                table: "Products",
                column: "MarkaCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MarkaCategory_MarkaCategoryId",
                table: "Products",
                column: "MarkaCategoryId",
                principalTable: "MarkaCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_MarkaCategory_MarkaCategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MarkaCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MarkaCategoryId",
                table: "Products");
        }
    }
}
