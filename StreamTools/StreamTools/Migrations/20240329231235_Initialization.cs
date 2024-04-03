using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamTools.Migrations
{
    /// <inheritdoc />
    public partial class Initialization : Migration
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
                    Description = table.Column<string>(type: "TEXT", nullable: true),
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
                name: "Shockers",
                columns: table => new
                {
                    Code = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shockers", x => x.Code);
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
                name: "CheerShocker",
                columns: table => new
                {
                    CheerId = table.Column<int>(type: "INTEGER", nullable: false),
                    ShockersCode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheerShocker", x => new { x.CheerId, x.ShockersCode });
                    table.ForeignKey(
                        name: "FK_CheerShocker_Cheers_CheerId",
                        column: x => x.CheerId,
                        principalTable: "Cheers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheerShocker_Shockers_ShockersCode",
                        column: x => x.ShockersCode,
                        principalTable: "Shockers",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RedeemShocker",
                columns: table => new
                {
                    RedeemId = table.Column<int>(type: "INTEGER", nullable: false),
                    ShockersCode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedeemShocker", x => new { x.RedeemId, x.ShockersCode });
                    table.ForeignKey(
                        name: "FK_RedeemShocker_Redeems_RedeemId",
                        column: x => x.RedeemId,
                        principalTable: "Redeems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RedeemShocker_Shockers_ShockersCode",
                        column: x => x.ShockersCode,
                        principalTable: "Shockers",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShockerSuperChat",
                columns: table => new
                {
                    ShockersCode = table.Column<string>(type: "TEXT", nullable: false),
                    SuperChatId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShockerSuperChat", x => new { x.ShockersCode, x.SuperChatId });
                    table.ForeignKey(
                        name: "FK_ShockerSuperChat_Shockers_ShockersCode",
                        column: x => x.ShockersCode,
                        principalTable: "Shockers",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShockerSuperChat_Superchats_SuperChatId",
                        column: x => x.SuperChatId,
                        principalTable: "Superchats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheerShocker_ShockersCode",
                table: "CheerShocker",
                column: "ShockersCode");

            migrationBuilder.CreateIndex(
                name: "IX_RedeemShocker_ShockersCode",
                table: "RedeemShocker",
                column: "ShockersCode");

            migrationBuilder.CreateIndex(
                name: "IX_ShockerSuperChat_SuperChatId",
                table: "ShockerSuperChat",
                column: "SuperChatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheerShocker");

            migrationBuilder.DropTable(
                name: "RedeemShocker");

            migrationBuilder.DropTable(
                name: "ShockerSuperChat");

            migrationBuilder.DropTable(
                name: "Cheers");

            migrationBuilder.DropTable(
                name: "Redeems");

            migrationBuilder.DropTable(
                name: "Shockers");

            migrationBuilder.DropTable(
                name: "Superchats");
        }
    }
}
