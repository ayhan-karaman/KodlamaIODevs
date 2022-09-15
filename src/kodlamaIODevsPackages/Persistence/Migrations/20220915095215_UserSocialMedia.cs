using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    public partial class UserSocialMedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_social_medias",
                columns: table => new
                {
                    user_social_media_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    social_media_name = table.Column<string>(type: "text", nullable: false),
                    url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_social_medias", x => x.user_social_media_id);
                    table.ForeignKey(
                        name: "FK_user_social_medias_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "user_social_medias",
                columns: new[] { "user_social_media_id", "social_media_name", "url", "user_id" },
                values: new object[,]
                {
                    { 1, "Github", "https://github.com/engindemirog/", 1 },
                    { 2, "Youtube", "https://linkedin.com/in/engindemirog", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_social_medias_user_id",
                table: "user_social_medias",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_social_medias");
        }
    }
}
