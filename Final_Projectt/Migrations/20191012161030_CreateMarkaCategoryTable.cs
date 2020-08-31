using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Projectt.Migrations
{
    public partial class CreateMarkaCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MarkaCategoryId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MarkaCategorys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MarkaId = table.Column<int>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarkaCategorys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarkaCategorys_Categorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MarkaCategorys_Markas_MarkaId",
                        column: x => x.MarkaId,
                        principalTable: "Markas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_MarkaCategoryId",
                table: "Products",
                column: "MarkaCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MarkaCategorys_CategoryId",
                table: "MarkaCategorys",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MarkaCategorys_MarkaId",
                table: "MarkaCategorys",
                column: "MarkaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MarkaCategorys_MarkaCategoryId",
                table: "Products",
                column: "MarkaCategoryId",
                principalTable: "MarkaCategorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_MarkaCategorys_MarkaCategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "MarkaCategorys");

            migrationBuilder.DropIndex(
                name: "IX_Products_MarkaCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MarkaCategoryId",
                table: "Products");
        }
    }
}
