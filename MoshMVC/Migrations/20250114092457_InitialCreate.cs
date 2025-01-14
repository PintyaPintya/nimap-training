using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoshMVC.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MembershipTypes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SignUpFee = table.Column<short>(type: "smallint", nullable: false),
                    DurationInMonths = table.Column<byte>(type: "tinyint", nullable: false),
                    DiscountRate = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ReleaseDate = table.Column<DateOnly>(type: "date", nullable: false),
                    DateAdded = table.Column<DateOnly>(type: "date", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: true),
                    isSubscribedToNewsLetter = table.Column<bool>(type: "bit", nullable: false),
                    MembershipTypeId = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_MembershipTypes_MembershipTypeId",
                        column: x => x.MembershipTypeId,
                        principalTable: "MembershipTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MembershipTypes",
                columns: new[] { "Id", "DiscountRate", "DurationInMonths", "Name", "SignUpFee" },
                values: new object[,]
                {
                    { (byte)1, (byte)0, (byte)0, "Pay as you go", (short)0 },
                    { (byte)2, (byte)10, (byte)1, "Monthly", (short)30 },
                    { (byte)3, (byte)15, (byte)3, "Quarterly", (short)90 },
                    { (byte)4, (byte)20, (byte)12, "Yearly", (short)300 }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "DateAdded", "Genre", "Name", "ReleaseDate", "Stock" },
                values: new object[,]
                {
                    { 1, new DateOnly(2025, 1, 13), "Drama", "The Shawshank Redemption", new DateOnly(1994, 9, 22), 3 },
                    { 2, new DateOnly(2025, 1, 13), "Crime", "The Godfather", new DateOnly(1972, 3, 24), 5 },
                    { 3, new DateOnly(2025, 1, 13), "Action", "The Dark Knight", new DateOnly(2008, 7, 18), 5 },
                    { 4, new DateOnly(2025, 1, 13), "Drama", "Forrest Gump", new DateOnly(1994, 7, 6), 5 },
                    { 5, new DateOnly(2025, 1, 13), "Sci-Fi", "Inception", new DateOnly(2010, 7, 16), 5 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BirthDate", "MembershipTypeId", "Name", "isSubscribedToNewsLetter" },
                values: new object[,]
                {
                    { 1, new DateOnly(2025, 1, 12), (byte)1, "Qwer Tyui", false },
                    { 2, null, (byte)2, "Asdf  Ghjk", true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_MembershipTypeId",
                table: "Customers",
                column: "MembershipTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "MembershipTypes");
        }
    }
}
