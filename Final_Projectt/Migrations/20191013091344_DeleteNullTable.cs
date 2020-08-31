using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Projectt.Migrations
{
    public partial class DeleteNullTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarkaCategorys_Categorys_CategoryId",
                table: "MarkaCategorys");

            migrationBuilder.DropForeignKey(
                name: "FK_MarkaCategorys_Markas_MarkaId",
                table: "MarkaCategorys");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_MarkaCategorys_MarkaCategoryId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "MarkaCategoryId",
                table: "Products",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductImages",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MarkaId",
                table: "MarkaCategorys",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "MarkaCategorys",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MarkaCategorys_Categorys_CategoryId",
                table: "MarkaCategorys",
                column: "CategoryId",
                principalTable: "Categorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MarkaCategorys_Markas_MarkaId",
                table: "MarkaCategorys",
                column: "MarkaId",
                principalTable: "Markas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MarkaCategorys_MarkaCategoryId",
                table: "Products",
                column: "MarkaCategoryId",
                principalTable: "MarkaCategorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarkaCategorys_Categorys_CategoryId",
                table: "MarkaCategorys");

            migrationBuilder.DropForeignKey(
                name: "FK_MarkaCategorys_Markas_MarkaId",
                table: "MarkaCategorys");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_MarkaCategorys_MarkaCategoryId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "MarkaCategoryId",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductImages",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MarkaId",
                table: "MarkaCategorys",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "MarkaCategorys",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_MarkaCategorys_Categorys_CategoryId",
                table: "MarkaCategorys",
                column: "CategoryId",
                principalTable: "Categorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MarkaCategorys_Markas_MarkaId",
                table: "MarkaCategorys",
                column: "MarkaId",
                principalTable: "Markas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MarkaCategorys_MarkaCategoryId",
                table: "Products",
                column: "MarkaCategoryId",
                principalTable: "MarkaCategorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
