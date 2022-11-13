using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.API.Data.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SetRole",
                columns: table => new
                {
                    IdRole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetRole", x => x.IdRole);
                });

            migrationBuilder.CreateTable(
                name: "SetUser",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(256)", maxLength: 256, nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetUser", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_SetUser_SetRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "SetRole",
                        principalColumn: "IdRole",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SetPay",
                columns: table => new
                {
                    PayID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayType = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetPay", x => x.PayID);
                    table.ForeignKey(
                        name: "FK_SetPay_SetUser_UserId",
                        column: x => x.UserId,
                        principalTable: "SetUser",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SetPay_UserId",
                table: "SetPay",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SetUser_RoleId",
                table: "SetUser",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SetPay");

            migrationBuilder.DropTable(
                name: "SetUser");

            migrationBuilder.DropTable(
                name: "SetRole");
        }
    }
}
