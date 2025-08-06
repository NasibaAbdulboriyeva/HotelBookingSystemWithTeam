using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBookingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomRoomType");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoomType",
                table: "Rooms");

            migrationBuilder.AddColumn<long>(
                name: "RoomTypeId",
                table: "Rooms",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomTypes_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId",
                principalTable: "RoomTypes",
                principalColumn: "RoomTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomTypes_RoomTypeId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomTypeId",
                table: "Rooms");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoomType",
                table: "Rooms",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "RoomRoomType",
                columns: table => new
                {
                    RoomTypesRoomTypeId = table.Column<long>(type: "bigint", nullable: false),
                    RoomsRoomId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomRoomType", x => new { x.RoomTypesRoomTypeId, x.RoomsRoomId });
                    table.ForeignKey(
                        name: "FK_RoomRoomType_RoomTypes_RoomTypesRoomTypeId",
                        column: x => x.RoomTypesRoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "RoomTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomRoomType_Rooms_RoomsRoomId",
                        column: x => x.RoomsRoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomRoomType_RoomsRoomId",
                table: "RoomRoomType",
                column: "RoomsRoomId");
        }
    }
}
