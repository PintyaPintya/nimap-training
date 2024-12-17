using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApiPractice.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "INTEGER", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    SupplierCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SupplierInfo = table.Column<string>(type: "TEXT", nullable: false),
                    StockQuantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "IsAvailable", "Name", "Price", "StockQuantity", "SupplierCost", "SupplierInfo" },
                values: new object[,]
                {
                    { 1, "Electronics", "High-end gaming laptop", true, "Laptop", 1500.99m, 50, 1200.00m, "Tech Supplier Co." },
                    { 2, "Electronics", "Latest model with advanced features", true, "Smartphone", 999.99m, 100, 750.00m, "Mobile Solutions Inc." },
                    { 3, "Furniture", "Ergonomic office chair", true, "Desk Chair", 299.99m, 25, 200.00m, "Furniture Plus Ltd." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
