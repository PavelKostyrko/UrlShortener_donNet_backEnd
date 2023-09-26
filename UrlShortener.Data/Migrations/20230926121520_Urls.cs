using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UrlShortener.Data.Migrations
{
    /// <inheritdoc />
    public partial class Urls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Urls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LongUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShortUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClicksCount = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urls", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Urls",
                columns: new[] { "Id", "ClicksCount", "Created", "LongUrl", "ShortUrl" },
                values: new object[,]
                {
                    { 1, 0, "26.09.2023 15:15:20", "https://metanit.com", "short.by/YFn1g4" },
                    { 2, 0, "26.09.2023 15:15:20", "https://learn.javascript.ru", "short.by/IFkSo1" },
                    { 3, 0, "26.09.2023 15:15:20", "https://rabota.by", "short.by/GTof2r" },
                    { 4, 0, "26.09.2023 15:15:20", "https://ru.legacy.reactjs.org", "short.by/Ar2Tyk" },
                    { 5, 0, "26.09.2023 15:15:20", "https://hub.docker.com/search?q=mysql&type=image", "short.by/of4I8g" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Urls");
        }
    }
}
