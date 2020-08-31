using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Projectt.Migrations
{
    public partial class UpdateProductTableDiscountColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Discount",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Discount",
                table: "Products",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
