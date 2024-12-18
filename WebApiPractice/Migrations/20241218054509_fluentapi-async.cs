﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApiPractice.Migrations
{
    /// <inheritdoc />
    public partial class fluentapiasync : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "DiscountRules",
                columns: table => new
                {
                    DiscountRuleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MinimumPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    MaximumDiscount = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountRules", x => x.DiscountRuleId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 1, "Electronics", "Electronic gadgets and devices" },
                    { 2, "Books", "Various genres of books" },
                    { 3, "Home Appliances", "Appliances for everyday home use" }
                });

            migrationBuilder.InsertData(
                table: "DiscountRules",
                columns: new[] { "DiscountRuleId", "MaximumDiscount", "MinimumPrice" },
                values: new object[,]
                {
                    { 1, 10m, 100m },
                    { 2, 20m, 500m },
                    { 3, 30m, 999m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Discount", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 2, "Bestselling novel with an intriguing plot", 0m, "Novel", 50m },
                    { 2, 3, "Compact microwave oven suitable for small kitchens", 10m, "Microwave", 150m },
                    { 3, 1, "Latest model smartphone with advanced features", 20m, "Smartphone", 800m },
                    { 4, 1, "High-performance laptop for gaming and productivity", 30m, "Laptop", 1200m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscountRules");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
