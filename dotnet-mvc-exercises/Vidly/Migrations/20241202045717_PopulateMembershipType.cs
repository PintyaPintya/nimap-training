using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly.Migrations
{
    /// <inheritdoc />
    public partial class PopulateMembershipType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSubscribed",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte>(
                name: "MembershipTypeId",
                table: "Customers",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "MembershipType",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    SignUpFee = table.Column<short>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DurationInMonths = table.Column<byte>(type: "tinyint", nullable: false),
                    DiscountRate = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipType", x => x.Id);
                });

            migrationBuilder.Sql("INSERT INTO MembershipType (Id, SignUpFee, Name, DurationInMonths, DiscountRate) VALUES (1, 0, 'PayAsYouGo', 0, 0)");
            migrationBuilder.Sql("INSERT INTO MembershipType (Id, SignUpFee, Name, DurationInMonths, DiscountRate) VALUES (2, 30, 'Monthly', 1, 10)");
            migrationBuilder.Sql("INSERT INTO MembershipType (Id, SignUpFee, Name, DurationInMonths, DiscountRate) VALUES (3, 90, 'Quarterly', 3, 15)");
            migrationBuilder.Sql("INSERT INTO MembershipType (Id, SignUpFee, Name, DurationInMonths, DiscountRate) VALUES (4, 300, 'Annual', 4, 15)");


            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsSubscribed", "MembershipTypeId" },
                values: new object[] { false, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IsSubscribed", "MembershipTypeId" },
                values: new object[] { true, (byte)3 });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_MembershipTypeId",
                table: "Customers",
                column: "MembershipTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_MembershipType_MembershipTypeId",
                table: "Customers",
                column: "MembershipTypeId",
                principalTable: "MembershipType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_MembershipType_MembershipTypeId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "MembershipType");

            migrationBuilder.DropIndex(
                name: "IX_Customers_MembershipTypeId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IsSubscribed",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "MembershipTypeId",
                table: "Customers");
        }
    }
}
