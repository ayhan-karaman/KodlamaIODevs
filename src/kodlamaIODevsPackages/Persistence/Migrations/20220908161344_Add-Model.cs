using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "technologies",
                columns: table => new
                {
                    technology_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    technology_language_id = table.Column<int>(type: "integer", nullable: false),
                    technology_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_technologies", x => x.technology_id);
                    table.ForeignKey(
                        name: "FK_technologies_languages_technology_language_id",
                        column: x => x.technology_language_id,
                        principalTable: "languages",
                        principalColumn: "language_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "languages",
                keyColumn: "language_id",
                keyValue: 1,
                column: "language_name",
                value: "Csharp");

            migrationBuilder.InsertData(
                table: "technologies",
                columns: new[] { "technology_id", "technology_language_id", "technology_name" },
                values: new object[,]
                {
                    { 1, 1, "Wpf" },
                    { 2, 1, "ASP.NET" },
                    { 3, 2, "Spring" },
                    { 4, 2, "Jsp" },
                    { 5, 3, "React" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_technologies_technology_language_id",
                table: "technologies",
                column: "technology_language_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "technologies");

            migrationBuilder.UpdateData(
                table: "languages",
                keyColumn: "language_id",
                keyValue: 1,
                column: "language_name",
                value: "CSharp");
        }
    }
}
