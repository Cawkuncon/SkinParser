using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParseTry.Migrations
{
    public partial class addResultItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResultItems",
                columns: table => new
                {
                    hash_name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    market_buy_order = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    buff_buy_max_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    market_price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    buff_sell_min_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    buff_steam_price_cny = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    buff_buy_num = table.Column<int>(type: "int", nullable: false),
                    buff_sell_num = table.Column<int>(type: "int", nullable: false),
                    market_popularity_7d = table.Column<int>(type: "int", nullable: true),
                    buff_exterior_localized_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    buff_type_localized_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    buff_url_buff = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    market_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    buff_steam_market_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    buff_original_icon_url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultItems", x => x.hash_name);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResultItems");
        }
    }
}
