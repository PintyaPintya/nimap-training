using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiPractice.Migrations
{
    /// <inheritdoc />
    public partial class FluentApi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SupplierCost",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SupplierInfo",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "StockQuantity",
                table: "Products",
                newName: "Stock");

            migrationBuilder.RenameColumn(
                name: "IsAvailable",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "ProductId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(8,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "CategoryId", "Price", "Stock" },
                values: new object[] { 1, 750.00m, 20 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "CategoryId", "Price", "Stock" },
                values: new object[] { 2, 500.00m, 50 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "CategoryId", "Name", "Price", "Stock" },
                values: new object[] { 3, "Headphones", 100.00m, 100 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Stock",
                table: "Products",
                newName: "StockQuantity");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Products",
                newName: "IsAvailable");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Products",
                newName: "Id");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "SupplierCost",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "SupplierInfo",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "Description", "IsAvailable", "Price", "StockQuantity", "SupplierCost", "SupplierInfo" },
                values: new object[] { "Electronics", "High-end gaming laptop", true, 1500.99m, 50, 1200.00m, "Tech Supplier Co." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "Description", "IsAvailable", "Price", "StockQuantity", "SupplierCost", "SupplierInfo" },
                values: new object[] { "Electronics", "Latest model with advanced features", true, 999.99m, 100, 750.00m, "Mobile Solutions Inc." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "Description", "IsAvailable", "Name", "Price", "StockQuantity", "SupplierCost", "SupplierInfo" },
                values: new object[] { "Furniture", "Ergonomic office chair", true, "Desk Chair", 299.99m, 25, 200.00m, "Furniture Plus Ltd." });
        }
    }
}
