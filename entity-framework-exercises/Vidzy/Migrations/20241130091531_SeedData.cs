using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vidzy.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreVideo_Genres_GenresGenreId",
                table: "GenreVideo");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreVideo_Videos_VideosVideoId",
                table: "GenreVideo");

            migrationBuilder.RenameColumn(
                name: "VideosVideoId",
                table: "GenreVideo",
                newName: "VideoId");

            migrationBuilder.RenameColumn(
                name: "GenresGenreId",
                table: "GenreVideo",
                newName: "GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_GenreVideo_VideosVideoId",
                table: "GenreVideo",
                newName: "IX_GenreVideo_VideoId");

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Comedy" },
                    { 3, "Drama" }
                });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "VideoId", "Name", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, "The Avengers", new DateTime(2012, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "The Hangover", new DateTime(2009, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Titanic", new DateTime(1997, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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

            migrationBuilder.AddForeignKey(
                name: "FK_GenreVideo_Genres_GenreId",
                table: "GenreVideo",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreVideo_Videos_VideoId",
                table: "GenreVideo",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "VideoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreVideo_Genres_GenreId",
                table: "GenreVideo");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreVideo_Videos_VideoId",
                table: "GenreVideo");

            migrationBuilder.DeleteData(
                table: "GenreVideo",
                keyColumns: new[] { "GenreId", "VideoId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "GenreVideo",
                keyColumns: new[] { "GenreId", "VideoId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "GenreVideo",
                keyColumns: new[] { "GenreId", "VideoId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "GenreVideo",
                keyColumns: new[] { "GenreId", "VideoId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "GenreVideo",
                keyColumns: new[] { "GenreId", "VideoId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "VideoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "VideoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "VideoId",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "VideoId",
                table: "GenreVideo",
                newName: "VideosVideoId");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "GenreVideo",
                newName: "GenresGenreId");

            migrationBuilder.RenameIndex(
                name: "IX_GenreVideo_VideoId",
                table: "GenreVideo",
                newName: "IX_GenreVideo_VideosVideoId");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreVideo_Genres_GenresGenreId",
                table: "GenreVideo",
                column: "GenresGenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreVideo_Videos_VideosVideoId",
                table: "GenreVideo",
                column: "VideosVideoId",
                principalTable: "Videos",
                principalColumn: "VideoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
