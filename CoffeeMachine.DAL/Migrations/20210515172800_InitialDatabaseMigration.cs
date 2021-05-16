using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeMachine.DAL.Migrations
{
    public partial class InitialDatabaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    DrinkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrinkName = table.Column<string>(nullable: true),
                    ContainsSugar = table.Column<bool>(nullable: false),
                    Price = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.DrinkId);
                });

            migrationBuilder.CreateTable(
                name: "MachineUsers",
                columns: table => new
                {
                    MachineUserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identifier = table.Column<string>(nullable: true),
                    AccountCreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineUsers", x => x.MachineUserId);
                });

            migrationBuilder.CreateTable(
                name: "Commands",
                columns: table => new
                {
                    CommandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommandIdentifier = table.Column<string>(nullable: true),
                    SugarQuantity = table.Column<int>(nullable: true),
                    UseOwnMug = table.Column<bool>(nullable: true),
                    MoneyInserted = table.Column<float>(nullable: false),
                    MoneyReturned = table.Column<float>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    RequestedDrinkId = table.Column<int>(nullable: false),
                    CommandTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commands", x => x.CommandId);
                    table.ForeignKey(
                        name: "FK_Commands_Drinks_RequestedDrinkId",
                        column: x => x.RequestedDrinkId,
                        principalTable: "Drinks",
                        principalColumn: "DrinkId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commands_MachineUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "MachineUsers",
                        principalColumn: "MachineUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "DrinkId", "ContainsSugar", "DrinkName", "Price" },
                values: new object[,]
                {
                    { 1, true, "Coffee", 0.25f },
                    { 2, true, "Tea", 0.75f },
                    { 3, true, "Choclate", 1f }
                });

            migrationBuilder.InsertData(
                table: "MachineUsers",
                columns: new[] { "MachineUserId", "AccountCreationDate", "Identifier" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "first-user" });

            migrationBuilder.CreateIndex(
                name: "IX_Commands_CommandIdentifier",
                table: "Commands",
                column: "CommandIdentifier",
                unique: true,
                filter: "[CommandIdentifier] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Commands_RequestedDrinkId",
                table: "Commands",
                column: "RequestedDrinkId");

            migrationBuilder.CreateIndex(
                name: "IX_Commands_UserId",
                table: "Commands",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Drinks_DrinkName",
                table: "Drinks",
                column: "DrinkName",
                unique: true,
                filter: "[DrinkName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MachineUsers_Identifier",
                table: "MachineUsers",
                column: "Identifier",
                unique: true,
                filter: "[Identifier] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commands");

            migrationBuilder.DropTable(
                name: "Drinks");

            migrationBuilder.DropTable(
                name: "MachineUsers");
        }
    }
}
