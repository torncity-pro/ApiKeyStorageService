using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiKeyStorageService.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TornApiKey",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false),
                    FactionId = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    ApiKey = table.Column<string>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    TrackPlayer = table.Column<bool>(nullable: false),
                    TrackFaction = table.Column<bool>(nullable: false),
                    TrackCompany = table.Column<bool>(nullable: false),
                    TrackTorn = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TornApiKey", x => x.PlayerId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TornApiKey_ApiKey",
                table: "TornApiKey",
                column: "ApiKey",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TornApiKey");
        }
    }
}
