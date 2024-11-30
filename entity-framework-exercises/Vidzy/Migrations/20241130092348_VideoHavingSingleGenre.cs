using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vidzy.Migrations
{
    /// <inheritdoc />
    public partial class VideoHavingSingleGenre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreVideo");

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Videos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "VideoId",
                keyValue: 1,
                column: "GenreId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "VideoId",
                keyValue: 2,
                column: "GenreId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "VideoId",
                keyValue: 3,
                column: "GenreId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Videos_GenreId",
                table: "Videos",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Genres_GenreId",
                table: "Videos",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Genres_GenreId",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_Videos_GenreId",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Videos");

            migrationBuilder.CreateTable(
                name: "GenreVideo",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    VideoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreVideo", x => new { x.GenreId, x.VideoId });
                    table.ForeignKey(
                        name: "FK_GenreVideo_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreVideo_Videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Videos",
                        principalColumn: "VideoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GenreVideo",
                columns: new[] { "GenreId", "VideoId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreVideo_VideoId",
                table: "GenreVideo",
                column: "VideoId");
        }
    }
}
