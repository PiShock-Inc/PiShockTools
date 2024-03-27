using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamTools.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cheers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Keyword = table.Column<string>(type: "TEXT", nullable: false),
                    MinimumCheer = table.Column<int>(type: "INTEGER", nullable: false),
                    Method = table.Column<int>(type: "INTEGER", nullable: false),
                    Intensity = table.Column<int>(type: "INTEGER", nullable: false),
                    Duration = table.Column<int>(type: "INTEGER", nullable: false),
                    Warning = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cheers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Redeems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Method = table.Column<int>(type: "INTEGER", nullable: false),
                    Intensity = table.Column<int>(type: "INTEGER", nullable: false),
                    Duration = table.Column<int>(type: "INTEGER", nullable: false),
                    Warning = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Redeems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Superchats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Keyword = table.Column<string>(type: "TEXT", nullable: false),
                    MinimumAmount = table.Column<int>(type: "INTEGER", nullable: false),
                    Method = table.Column<int>(type: "INTEGER", nullable: false),
                    Intensity = table.Column<int>(type: "INTEGER", nullable: false),
                    Duration = table.Column<int>(type: "INTEGER", nullable: false),
                    Warning = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Superchats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shockers",
                columns: table => new
                {
                    Code = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    CheerId = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    RedeemId = table.Column<int>(type: "INTEGER", nullable: true),
                    SuperChatId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shockers", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Shockers_Cheers_CheerId",
                        column: x => x.CheerId,
                        principalTable: "Cheers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Shockers_Redeems_RedeemId",
                        column: x => x.RedeemId,
                        principalTable: "Redeems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Shockers_Superchats_SuperChatId",
                        column: x => x.SuperChatId,
                        principalTable: "Superchats",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shockers_CheerId",
                table: "Shockers",
                column: "CheerId");

            migrationBuilder.CreateIndex(
                name: "IX_Shockers_RedeemId",
                table: "Shockers",
                column: "RedeemId");

            migrationBuilder.CreateIndex(
                name: "IX_Shockers_SuperChatId",
                table: "Shockers",
                column: "SuperChatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shockers");

            migrationBuilder.DropTable(
                name: "Cheers");

            migrationBuilder.DropTable(
                name: "Redeems");

            migrationBuilder.DropTable(
                name: "Superchats");
        }
    }
}
