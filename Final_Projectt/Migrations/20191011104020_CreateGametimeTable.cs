using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Projectt.Migrations
{
    public partial class CreateGametimeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gametimes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BackgorundImage = table.Column<string>(maxLength: 255, nullable: false),
                    Title1 = table.Column<string>(maxLength: 100, nullable: false),
                    Title2 = table.Column<string>(maxLength: 150, nullable: false),
                    SmallImage = table.Column<string>(maxLength: 255, nullable: false),
                    BigImage1 = table.Column<string>(maxLength: 255, nullable: false),
                    BigImage2 = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gametimes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gametimes");
        }
    }
}
