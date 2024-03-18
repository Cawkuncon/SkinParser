using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParseTry.Migrations
{
    public partial class chItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    buy_order = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    avg_price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    popularity_7d = table.Column<int>(type: "int", nullable: true),
                    market_hash_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ru_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ru_rarity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ru_quality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
