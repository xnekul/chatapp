using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class fixed_FK_for_room : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoom_Rooms_StudentId",
                table: "UserRoom");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "UserRoom",
                newName: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoom_Rooms_RoomId",
                table: "UserRoom",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoom_Rooms_RoomId",
                table: "UserRoom");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "UserRoom",
                newName: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoom_Rooms_StudentId",
                table: "UserRoom",
                column: "StudentId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
