using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.API.Data.Migrations
{
    public partial class editDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SetPay_SetUser_UserId",
                table: "SetPay");

            migrationBuilder.DropForeignKey(
                name: "FK_SetProduct_SetCate_IdCate",
                table: "SetProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_SetUser_SetRole_RoleId",
                table: "SetUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SetUser",
                table: "SetUser");

            migrationBuilder.DropIndex(
                name: "IX_SetUser_RoleId",
                table: "SetUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SetRole",
                table: "SetRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SetProduct",
                table: "SetProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SetPay",
                table: "SetPay");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SetCate",
                table: "SetCate");

            migrationBuilder.RenameTable(
                name: "SetUser",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "SetRole",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "SetProduct",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "SetPay",
                newName: "UserPays");

            migrationBuilder.RenameTable(
                name: "SetCate",
                newName: "Categories");

            migrationBuilder.RenameColumn(
                name: "feedback",
                table: "Products",
                newName: "Feedback");

            migrationBuilder.RenameColumn(
                name: "discount",
                table: "Products",
                newName: "Discount");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Products",
                newName: "Frice");

            migrationBuilder.RenameIndex(
                name: "IX_SetProduct_IdCate",
                table: "Products",
                newName: "IX_Products_IdCate");

            migrationBuilder.RenameIndex(
                name: "IX_SetPay_UserId",
                table: "UserPays",
                newName: "IX_UserPays_UserId");

            migrationBuilder.RenameColumn(
                name: "categoryType",
                table: "Categories",
                newName: "CategoryType");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryType",
                table: "Categories",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "IdUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "IdRole");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "IdProduct");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPays",
                table: "UserPays",
                column: "PayID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MethodPays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MethodPays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    IdOrder = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.IdOrder);
                    table.ForeignKey(
                        name: "FK_Orders_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductFeeds",
                columns: table => new
                {
                    IdFeed = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    star = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFeeds", x => x.IdFeed);
                    table.ForeignKey(
                        name: "FK_ProductFeeds_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "IdProduct",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductFeeds_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProduct = table.Column<int>(type: "int", nullable: false),
                    IdCart = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_IdCart",
                        column: x => x.IdCart,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "Products",
                        principalColumn: "IdProduct",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    IdOrderProduct = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrder = table.Column<int>(type: "int", nullable: false),
                    IdProduct = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => x.IdOrderProduct);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_IdOrder",
                        column: x => x.IdOrder,
                        principalTable: "Orders",
                        principalColumn: "IdOrder",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "Products",
                        principalColumn: "IdProduct",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    IdPay = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrder = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypePay = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.IdPay);
                    table.ForeignKey(
                        name: "FK_Payments_MethodPays_TypePay",
                        column: x => x.TypePay,
                        principalTable: "MethodPays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_IdOrder",
                        column: x => x.IdOrder,
                        principalTable: "Orders",
                        principalColumn: "IdOrder",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_IdCart",
                table: "CartItems",
                column: "IdCart");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_IdProduct",
                table: "CartItems",
                column: "IdProduct",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_IdUser",
                table: "Carts",
                column: "IdUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_IdOrder",
                table: "OrderProducts",
                column: "IdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_IdProduct",
                table: "OrderProducts",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdUser",
                table: "Orders",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_IdOrder",
                table: "Payments",
                column: "IdOrder",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_TypePay",
                table: "Payments",
                column: "TypePay");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeeds_ProductID",
                table: "ProductFeeds",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeeds_UserID",
                table: "ProductFeeds",
                column: "UserID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_IdCate",
                table: "Products",
                column: "IdCate",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPays_Users_UserId",
                table: "UserPays",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "IdRole",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_IdCate",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPays_Users_UserId",
                table: "UserPays");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "ProductFeeds");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "MethodPays");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPays",
                table: "UserPays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "SetUser");

            migrationBuilder.RenameTable(
                name: "UserPays",
                newName: "SetPay");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "SetRole");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "SetProduct");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "SetCate");

            migrationBuilder.RenameIndex(
                name: "IX_UserPays_UserId",
                table: "SetPay",
                newName: "IX_SetPay_UserId");

            migrationBuilder.RenameColumn(
                name: "Feedback",
                table: "SetProduct",
                newName: "feedback");

            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "SetProduct",
                newName: "discount");

            migrationBuilder.RenameColumn(
                name: "Frice",
                table: "SetProduct",
                newName: "price");

            migrationBuilder.RenameIndex(
                name: "IX_Products_IdCate",
                table: "SetProduct",
                newName: "IX_SetProduct_IdCate");

            migrationBuilder.RenameColumn(
                name: "CategoryType",
                table: "SetCate",
                newName: "categoryType");

            migrationBuilder.AlterColumn<string>(
                name: "categoryType",
                table: "SetCate",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SetUser",
                table: "SetUser",
                column: "IdUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SetPay",
                table: "SetPay",
                column: "PayID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SetRole",
                table: "SetRole",
                column: "IdRole");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SetProduct",
                table: "SetProduct",
                column: "IdProduct");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SetCate",
                table: "SetCate",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SetUser_RoleId",
                table: "SetUser",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_SetPay_SetUser_UserId",
                table: "SetPay",
                column: "UserId",
                principalTable: "SetUser",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SetProduct_SetCate_IdCate",
                table: "SetProduct",
                column: "IdCate",
                principalTable: "SetCate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SetUser_SetRole_RoleId",
                table: "SetUser",
                column: "RoleId",
                principalTable: "SetRole",
                principalColumn: "IdRole",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
