using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment2_EFcore_au529152.Migrations
{
    public partial class SampleDataTry1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Review_reviewId",
                table: "Dish");

            migrationBuilder.DropForeignKey(
                name: "FK_DishType_Dish_dishId",
                table: "DishType");

            migrationBuilder.DropForeignKey(
                name: "FK_Guest_Review_reviewId",
                table: "Guest");

            migrationBuilder.DropForeignKey(
                name: "FK_Guest_MyTable_tableNumber",
                table: "Guest");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestDish_Dish_dishId",
                table: "GuestDish");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestDish_Guest_guestId",
                table: "GuestDish");

            migrationBuilder.DropForeignKey(
                name: "FK_MyTable_Resturant_resturantAddress",
                table: "MyTable");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Guest_id",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Waiter_waiterid",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_ResturantDish_Dish_DishId",
                table: "ResturantDish");

            migrationBuilder.DropForeignKey(
                name: "FK_ResturantDish_Resturant_ResturantAddress",
                table: "ResturantDish");

            migrationBuilder.DropForeignKey(
                name: "FK_ResturantType_Resturant_resturantAdress",
                table: "ResturantType");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Resturant_resturantAddress",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_WaiterTable_MyTable_tableNumber",
                table: "WaiterTable");

            migrationBuilder.DropForeignKey(
                name: "FK_WaiterTable_Waiter_waiterId",
                table: "WaiterTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Waiter",
                table: "Waiter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resturant",
                table: "Resturant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyTable",
                table: "MyTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guest",
                table: "Guest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dish",
                table: "Dish");

            migrationBuilder.RenameTable(
                name: "Waiter",
                newName: "Waiters");

            migrationBuilder.RenameTable(
                name: "Review",
                newName: "Reviews");

            migrationBuilder.RenameTable(
                name: "Resturant",
                newName: "Resturants");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "Persons");

            migrationBuilder.RenameTable(
                name: "MyTable",
                newName: "MyTables");

            migrationBuilder.RenameTable(
                name: "Guest",
                newName: "Guests");

            migrationBuilder.RenameTable(
                name: "Dish",
                newName: "Dishes");

            migrationBuilder.RenameIndex(
                name: "IX_Review_resturantAddress",
                table: "Reviews",
                newName: "IX_Reviews_resturantAddress");

            migrationBuilder.RenameIndex(
                name: "IX_Person_waiterid",
                table: "Persons",
                newName: "IX_Persons_waiterid");

            migrationBuilder.RenameIndex(
                name: "IX_MyTable_resturantAddress",
                table: "MyTables",
                newName: "IX_MyTables_resturantAddress");

            migrationBuilder.RenameIndex(
                name: "IX_Guest_tableNumber",
                table: "Guests",
                newName: "IX_Guests_tableNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Guest_reviewId",
                table: "Guests",
                newName: "IX_Guests_reviewId");

            migrationBuilder.RenameIndex(
                name: "IX_Dish_reviewId",
                table: "Dishes",
                newName: "IX_Dishes_reviewId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Waiters",
                table: "Waiters",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resturants",
                table: "Resturants",
                column: "address");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyTables",
                table: "MyTables",
                column: "Number");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guests",
                table: "Guests",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes",
                column: "id");

            migrationBuilder.InsertData(
                table: "Resturants",
                columns: new[] { "address", "name" },
                values: new object[] { "Oldtimers road 7", "MorMor's kitchen" });

            migrationBuilder.InsertData(
                table: "Resturants",
                columns: new[] { "address", "name" },
                values: new object[] { "Wierdo streed 13", "Dare to eat it?" });

            migrationBuilder.InsertData(
                table: "Resturants",
                columns: new[] { "address", "name" },
                values: new object[] { "Mortlilty street 5", "Canibal stew" });

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Reviews_reviewId",
                table: "Dishes",
                column: "reviewId",
                principalTable: "Reviews",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DishType_Dishes_dishId",
                table: "DishType",
                column: "dishId",
                principalTable: "Dishes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestDish_Dishes_dishId",
                table: "GuestDish",
                column: "dishId",
                principalTable: "Dishes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestDish_Guests_guestId",
                table: "GuestDish",
                column: "guestId",
                principalTable: "Guests",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Reviews_reviewId",
                table: "Guests",
                column: "reviewId",
                principalTable: "Reviews",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_MyTables_tableNumber",
                table: "Guests",
                column: "tableNumber",
                principalTable: "MyTables",
                principalColumn: "Number",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MyTables_Resturants_resturantAddress",
                table: "MyTables",
                column: "resturantAddress",
                principalTable: "Resturants",
                principalColumn: "address",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Guests_id",
                table: "Persons",
                column: "id",
                principalTable: "Guests",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Waiters_waiterid",
                table: "Persons",
                column: "waiterid",
                principalTable: "Waiters",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResturantDish_Dishes_DishId",
                table: "ResturantDish",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResturantDish_Resturants_ResturantAddress",
                table: "ResturantDish",
                column: "ResturantAddress",
                principalTable: "Resturants",
                principalColumn: "address",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResturantType_Resturants_resturantAdress",
                table: "ResturantType",
                column: "resturantAdress",
                principalTable: "Resturants",
                principalColumn: "address",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Resturants_resturantAddress",
                table: "Reviews",
                column: "resturantAddress",
                principalTable: "Resturants",
                principalColumn: "address",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WaiterTable_MyTables_tableNumber",
                table: "WaiterTable",
                column: "tableNumber",
                principalTable: "MyTables",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WaiterTable_Waiters_waiterId",
                table: "WaiterTable",
                column: "waiterId",
                principalTable: "Waiters",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Reviews_reviewId",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_DishType_Dishes_dishId",
                table: "DishType");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestDish_Dishes_dishId",
                table: "GuestDish");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestDish_Guests_guestId",
                table: "GuestDish");

            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Reviews_reviewId",
                table: "Guests");

            migrationBuilder.DropForeignKey(
                name: "FK_Guests_MyTables_tableNumber",
                table: "Guests");

            migrationBuilder.DropForeignKey(
                name: "FK_MyTables_Resturants_resturantAddress",
                table: "MyTables");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Guests_id",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Waiters_waiterid",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_ResturantDish_Dishes_DishId",
                table: "ResturantDish");

            migrationBuilder.DropForeignKey(
                name: "FK_ResturantDish_Resturants_ResturantAddress",
                table: "ResturantDish");

            migrationBuilder.DropForeignKey(
                name: "FK_ResturantType_Resturants_resturantAdress",
                table: "ResturantType");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Resturants_resturantAddress",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_WaiterTable_MyTables_tableNumber",
                table: "WaiterTable");

            migrationBuilder.DropForeignKey(
                name: "FK_WaiterTable_Waiters_waiterId",
                table: "WaiterTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Waiters",
                table: "Waiters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resturants",
                table: "Resturants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyTables",
                table: "MyTables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guests",
                table: "Guests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes");

            migrationBuilder.DeleteData(
                table: "Resturants",
                keyColumn: "address",
                keyValue: "Mortlilty street 5");

            migrationBuilder.DeleteData(
                table: "Resturants",
                keyColumn: "address",
                keyValue: "Oldtimers road 7");

            migrationBuilder.DeleteData(
                table: "Resturants",
                keyColumn: "address",
                keyValue: "Wierdo streed 13");

            migrationBuilder.RenameTable(
                name: "Waiters",
                newName: "Waiter");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Review");

            migrationBuilder.RenameTable(
                name: "Resturants",
                newName: "Resturant");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "Person");

            migrationBuilder.RenameTable(
                name: "MyTables",
                newName: "MyTable");

            migrationBuilder.RenameTable(
                name: "Guests",
                newName: "Guest");

            migrationBuilder.RenameTable(
                name: "Dishes",
                newName: "Dish");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_resturantAddress",
                table: "Review",
                newName: "IX_Review_resturantAddress");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_waiterid",
                table: "Person",
                newName: "IX_Person_waiterid");

            migrationBuilder.RenameIndex(
                name: "IX_MyTables_resturantAddress",
                table: "MyTable",
                newName: "IX_MyTable_resturantAddress");

            migrationBuilder.RenameIndex(
                name: "IX_Guests_tableNumber",
                table: "Guest",
                newName: "IX_Guest_tableNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Guests_reviewId",
                table: "Guest",
                newName: "IX_Guest_reviewId");

            migrationBuilder.RenameIndex(
                name: "IX_Dishes_reviewId",
                table: "Dish",
                newName: "IX_Dish_reviewId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Waiter",
                table: "Waiter",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resturant",
                table: "Resturant",
                column: "address");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyTable",
                table: "MyTable",
                column: "Number");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guest",
                table: "Guest",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dish",
                table: "Dish",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Review_reviewId",
                table: "Dish",
                column: "reviewId",
                principalTable: "Review",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DishType_Dish_dishId",
                table: "DishType",
                column: "dishId",
                principalTable: "Dish",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Guest_Review_reviewId",
                table: "Guest",
                column: "reviewId",
                principalTable: "Review",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Guest_MyTable_tableNumber",
                table: "Guest",
                column: "tableNumber",
                principalTable: "MyTable",
                principalColumn: "Number",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestDish_Dish_dishId",
                table: "GuestDish",
                column: "dishId",
                principalTable: "Dish",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestDish_Guest_guestId",
                table: "GuestDish",
                column: "guestId",
                principalTable: "Guest",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MyTable_Resturant_resturantAddress",
                table: "MyTable",
                column: "resturantAddress",
                principalTable: "Resturant",
                principalColumn: "address",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Guest_id",
                table: "Person",
                column: "id",
                principalTable: "Guest",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Waiter_waiterid",
                table: "Person",
                column: "waiterid",
                principalTable: "Waiter",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResturantDish_Dish_DishId",
                table: "ResturantDish",
                column: "DishId",
                principalTable: "Dish",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResturantDish_Resturant_ResturantAddress",
                table: "ResturantDish",
                column: "ResturantAddress",
                principalTable: "Resturant",
                principalColumn: "address",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResturantType_Resturant_resturantAdress",
                table: "ResturantType",
                column: "resturantAdress",
                principalTable: "Resturant",
                principalColumn: "address",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Resturant_resturantAddress",
                table: "Review",
                column: "resturantAddress",
                principalTable: "Resturant",
                principalColumn: "address",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WaiterTable_MyTable_tableNumber",
                table: "WaiterTable",
                column: "tableNumber",
                principalTable: "MyTable",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WaiterTable_Waiter_waiterId",
                table: "WaiterTable",
                column: "waiterId",
                principalTable: "Waiter",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
