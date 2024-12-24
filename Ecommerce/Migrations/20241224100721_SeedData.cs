using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Email", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, "123 Main St", "john.doe@example.com", false, "John Doe" },
                    { 2, "456 Elm St", "jane.smith@example.com", false, "Jane Smith" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "IsDeleted", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, "4K Ultra HD TV", false, "TV", 499.99m, 50 },
                    { 2, "High-performance laptop", false, "Laptop", 999.99m, 30 },
                    { 3, "Latest model smartphone", false, "Smartphone", 799.99m, 100 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "OrderDate", "Status", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", 1499.97m },
                    { 2, 2, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", 999.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
