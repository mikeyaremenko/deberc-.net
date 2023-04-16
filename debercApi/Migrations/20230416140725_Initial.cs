using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace debercApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Index = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    FirstPlayerId = table.Column<int>(type: "int", nullable: true),
                    SecondPlayerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Team_Player_FirstPlayerId",
                        column: x => x.FirstPlayerId,
                        principalTable: "Player",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Team_Player_SecondPlayerId",
                        column: x => x.SecondPlayerId,
                        principalTable: "Player",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    FirstTeamId = table.Column<int>(type: "int", nullable: true),
                    SecondTeamId = table.Column<int>(type: "int", nullable: true),
                    DealerId = table.Column<int>(type: "int", nullable: true),
                    OpenPoints = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Player_DealerId",
                        column: x => x.DealerId,
                        principalTable: "Player",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Games_Team_FirstTeamId",
                        column: x => x.FirstTeamId,
                        principalTable: "Team",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Games_Team_SecondTeamId",
                        column: x => x.SecondTeamId,
                        principalTable: "Team",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Suit = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: true),
                    TrickId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Player_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Player",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Round",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayedCardId = table.Column<int>(type: "int", nullable: true),
                    DutyPlayerId = table.Column<int>(type: "int", nullable: true),
                    OrderSuit = table.Column<int>(type: "int", nullable: false),
                    OrderPlayerId = table.Column<int>(type: "int", nullable: true),
                    VotePlayerId = table.Column<int>(type: "int", nullable: true),
                    BargainRound = table.Column<int>(type: "int", nullable: false),
                    OwnerGameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Round", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Round_Cards_DisplayedCardId",
                        column: x => x.DisplayedCardId,
                        principalTable: "Cards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Round_Games_OwnerGameId",
                        column: x => x.OwnerGameId,
                        principalTable: "Games",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Round_Player_DutyPlayerId",
                        column: x => x.DutyPlayerId,
                        principalTable: "Player",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Round_Player_OrderPlayerId",
                        column: x => x.OrderPlayerId,
                        principalTable: "Player",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Round_Player_VotePlayerId",
                        column: x => x.VotePlayerId,
                        principalTable: "Player",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Combinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    OwnerTeamId = table.Column<int>(type: "int", nullable: true),
                    Score = table.Column<int>(type: "int", nullable: false),
                    GameRoundId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Combinations_Round_GameRoundId",
                        column: x => x.GameRoundId,
                        principalTable: "Round",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Combinations_Team_OwnerTeamId",
                        column: x => x.OwnerTeamId,
                        principalTable: "Team",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Trick",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WinnerTeamId = table.Column<int>(type: "int", nullable: true),
                    StarterPlayerId = table.Column<int>(type: "int", nullable: true),
                    Score = table.Column<int>(type: "int", nullable: false),
                    OwnerRoundId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trick", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trick_Player_StarterPlayerId",
                        column: x => x.StarterPlayerId,
                        principalTable: "Player",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trick_Round_OwnerRoundId",
                        column: x => x.OwnerRoundId,
                        principalTable: "Round",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trick_Team_WinnerTeamId",
                        column: x => x.WinnerTeamId,
                        principalTable: "Team",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_OwnerId",
                table: "Cards",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_TrickId",
                table: "Cards",
                column: "TrickId");

            migrationBuilder.CreateIndex(
                name: "IX_Combinations_GameRoundId",
                table: "Combinations",
                column: "GameRoundId");

            migrationBuilder.CreateIndex(
                name: "IX_Combinations_OwnerTeamId",
                table: "Combinations",
                column: "OwnerTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_DealerId",
                table: "Games",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_FirstTeamId",
                table: "Games",
                column: "FirstTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_SecondTeamId",
                table: "Games",
                column: "SecondTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Round_DisplayedCardId",
                table: "Round",
                column: "DisplayedCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Round_DutyPlayerId",
                table: "Round",
                column: "DutyPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Round_OrderPlayerId",
                table: "Round",
                column: "OrderPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Round_OwnerGameId",
                table: "Round",
                column: "OwnerGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Round_VotePlayerId",
                table: "Round",
                column: "VotePlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_FirstPlayerId",
                table: "Team",
                column: "FirstPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_SecondPlayerId",
                table: "Team",
                column: "SecondPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Trick_OwnerRoundId",
                table: "Trick",
                column: "OwnerRoundId");

            migrationBuilder.CreateIndex(
                name: "IX_Trick_StarterPlayerId",
                table: "Trick",
                column: "StarterPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Trick_WinnerTeamId",
                table: "Trick",
                column: "WinnerTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Trick_TrickId",
                table: "Cards",
                column: "TrickId",
                principalTable: "Trick",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Player_OwnerId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Player_DealerId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Round_Player_DutyPlayerId",
                table: "Round");

            migrationBuilder.DropForeignKey(
                name: "FK_Round_Player_OrderPlayerId",
                table: "Round");

            migrationBuilder.DropForeignKey(
                name: "FK_Round_Player_VotePlayerId",
                table: "Round");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_Player_FirstPlayerId",
                table: "Team");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_Player_SecondPlayerId",
                table: "Team");

            migrationBuilder.DropForeignKey(
                name: "FK_Trick_Player_StarterPlayerId",
                table: "Trick");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Trick_TrickId",
                table: "Cards");

            migrationBuilder.DropTable(
                name: "Combinations");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Trick");

            migrationBuilder.DropTable(
                name: "Round");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
