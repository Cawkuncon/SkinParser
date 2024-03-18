using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParseTry.Migrations
{
    public partial class addDivPrices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "pricesBM",
                table: "ResultItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "pricesBS",
                table: "ResultItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "pricesMB",
                table: "ResultItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "pricesMS",
                table: "ResultItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "pricesSB",
                table: "ResultItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "pricesSM",
                table: "ResultItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "Items",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "buy_order",
                table: "Items",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pricesBM",
                table: "ResultItems");

            migrationBuilder.DropColumn(
                name: "pricesBS",
                table: "ResultItems");

            migrationBuilder.DropColumn(
                name: "pricesMB",
                table: "ResultItems");

            migrationBuilder.DropColumn(
                name: "pricesMS",
                table: "ResultItems");

            migrationBuilder.DropColumn(
                name: "pricesSB",
                table: "ResultItems");

            migrationBuilder.DropColumn(
                name: "pricesSM",
                table: "ResultItems");

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "Items",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "buy_order",
                table: "Items",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
