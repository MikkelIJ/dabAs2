using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment2_EFcore_au529152.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Waiter");

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    waiterid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.id);
                    table.ForeignKey(
                        name: "FK_Person_Guest_id",
                        column: x => x.id,
                        principalTable: "Guest",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Person_Waiter_waiterid",
                        column: x => x.waiterid,
                        principalTable: "Waiter",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_waiterid",
                table: "Person",
                column: "waiterid",
                unique: true,
                filter: "[waiterid] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Waiter",
                nullable: true);
        }
    }
}
