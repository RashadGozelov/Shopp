using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Projectt.Migrations
{
    public partial class DeleteMarkaCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_MarkaCategory_MarkaCategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "MarkaCategory");

            migrationBuilder.DropIndex(
                name: "IX_Products_MarkaCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MarkaCategoryId",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MarkaCategoryId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MarkaCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<int>(nullable: true),
                    MarkaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarkaCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarkaCategory_Categorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MarkaCategory_Markas_MarkaId",
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
                name: "IX_MarkaCategory_CategoryId",
                table: "MarkaCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MarkaCategory_MarkaId",
                table: "MarkaCategory",
                column: "MarkaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MarkaCategory_MarkaCategoryId",
                table: "Products",
                column: "MarkaCategoryId",
                principalTable: "MarkaCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
