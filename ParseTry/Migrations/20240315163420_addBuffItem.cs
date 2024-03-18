using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParseTry.Migrations
{
    public partial class addBuffItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuffItems",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    buy_max_price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    buy_num = table.Column<int>(type: "int", nullable: false),
                    original_icon_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    steam_price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    steam_price_cny = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    market_hash_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quick_price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sell_min_price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sell_num = table.Column<int>(type: "int", nullable: false),
                    sell_reference_price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    steam_market_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    exterior_localized_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type_localized_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuffItems", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuffItems");
        }
    }
}
