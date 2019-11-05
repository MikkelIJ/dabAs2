using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment2_EFcore_au529152.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "reviewId",
                table: "Dish",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DishType",
                columns: table => new
                {
                    dishTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    type = table.Column<string>(nullable: true),
                    dishId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishType", x => x.dishTypeId);
                    table.ForeignKey(
                        name: "FK_DishType_Dish_dishId",
                        column: x => x.dishId,
                        principalTable: "Dish",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resturant",
                columns: table => new
                {
                    address = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resturant", x => x.address);
                });

            migrationBuilder.CreateTable(
                name: "Waiter",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    salary = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waiter", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MyTable",
                columns: table => new
                {
                    Number = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    resturantAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyTable", x => x.Number);
                    table.ForeignKey(
                        name: "FK_MyTable_Resturant_resturantAddress",
                        column: x => x.resturantAddress,
                        principalTable: "Resturant",
                        principalColumn: "address",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResturantDish",
                columns: table => new
                {
                    ResturantDishId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DishId = table.Column<int>(nullable: false),
                    ResturantAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResturantDish", x => x.ResturantDishId);
                    table.ForeignKey(
                        name: "FK_ResturantDish_Dish_DishId",
                        column: x => x.DishId,
                        principalTable: "Dish",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResturantDish_Resturant_ResturantAddress",
                        column: x => x.ResturantAddress,
                        principalTable: "Resturant",
                        principalColumn: "address",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResturantType",
                columns: table => new
                {
                    resturantTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    type = table.Column<string>(nullable: true),
                    resturantAdress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResturantType", x => x.resturantTypeId);
                    table.ForeignKey(
                        name: "FK_ResturantType_Resturant_resturantAdress",
                        column: x => x.resturantAdress,
                        principalTable: "Resturant",
                        principalColumn: "address",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    stars = table.Column<int>(nullable: false),
                    text = table.Column<string>(nullable: true),
                    resturantAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.id);
                    table.ForeignKey(
                        name: "FK_Review_Resturant_resturantAddress",
                        column: x => x.resturantAddress,
                        principalTable: "Resturant",
                        principalColumn: "address",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WaiterTable",
                columns: table => new
                {
                    waiterTableId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    waiterId = table.Column<int>(nullable: false),
                    tableNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaiterTable", x => x.waiterTableId);
                    table.ForeignKey(
                        name: "FK_WaiterTable_MyTable_tableNumber",
                        column: x => x.tableNumber,
                        principalTable: "MyTable",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WaiterTable_Waiter_waiterId",
                        column: x => x.waiterId,
                        principalTable: "Waiter",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Guest",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Time = table.Column<DateTime>(nullable: false),
                    reviewId = table.Column<int>(nullable: false),
                    tableNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guest", x => x.id);
                    table.ForeignKey(
                        name: "FK_Guest_Review_reviewId",
                        column: x => x.reviewId,
                        principalTable: "Review",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Guest_MyTable_tableNumber",
                        column: x => x.tableNumber,
                        principalTable: "MyTable",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GuestDish",
                columns: table => new
                {
                    guestDishId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    guestId = table.Column<int>(nullable: false),
                    dishId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestDish", x => x.guestDishId);
                    table.ForeignKey(
                        name: "FK_GuestDish_Dish_dishId",
                        column: x => x.dishId,
                        principalTable: "Dish",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuestDish_Guest_guestId",
                        column: x => x.guestId,
                        principalTable: "Guest",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dish_reviewId",
                table: "Dish",
                column: "reviewId");

            migrationBuilder.CreateIndex(
                name: "IX_DishType_dishId",
                table: "DishType",
                column: "dishId");

            migrationBuilder.CreateIndex(
                name: "IX_Guest_reviewId",
                table: "Guest",
                column: "reviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Guest_tableNumber",
                table: "Guest",
                column: "tableNumber");

            migrationBuilder.CreateIndex(
                name: "IX_GuestDish_dishId",
                table: "GuestDish",
                column: "dishId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestDish_guestId",
                table: "GuestDish",
                column: "guestId");

            migrationBuilder.CreateIndex(
                name: "IX_MyTable_resturantAddress",
                table: "MyTable",
                column: "resturantAddress");

            migrationBuilder.CreateIndex(
                name: "IX_ResturantDish_DishId",
                table: "ResturantDish",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_ResturantDish_ResturantAddress",
                table: "ResturantDish",
                column: "ResturantAddress");

            migrationBuilder.CreateIndex(
                name: "IX_ResturantType_resturantAdress",
                table: "ResturantType",
                column: "resturantAdress");

            migrationBuilder.CreateIndex(
                name: "IX_Review_resturantAddress",
                table: "Review",
                column: "resturantAddress");

            migrationBuilder.CreateIndex(
                name: "IX_WaiterTable_tableNumber",
                table: "WaiterTable",
                column: "tableNumber");

            migrationBuilder.CreateIndex(
                name: "IX_WaiterTable_waiterId",
                table: "WaiterTable",
                column: "waiterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Review_reviewId",
                table: "Dish",
                column: "reviewId",
                principalTable: "Review",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Review_reviewId",
                table: "Dish");

            migrationBuilder.DropTable(
                name: "DishType");

            migrationBuilder.DropTable(
                name: "GuestDish");

            migrationBuilder.DropTable(
                name: "ResturantDish");

            migrationBuilder.DropTable(
                name: "ResturantType");

            migrationBuilder.DropTable(
                name: "WaiterTable");

            migrationBuilder.DropTable(
                name: "Guest");

            migrationBuilder.DropTable(
                name: "Waiter");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "MyTable");

            migrationBuilder.DropTable(
                name: "Resturant");

            migrationBuilder.DropIndex(
                name: "IX_Dish_reviewId",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "reviewId",
                table: "Dish");
        }
    }
}
