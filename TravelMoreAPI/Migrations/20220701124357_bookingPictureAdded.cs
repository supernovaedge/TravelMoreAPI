using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelMoreAPI.Migrations
{
    public partial class bookingPictureAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GuestPictureUserId",
                table: "Bookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_GuestPictureUserId",
                table: "Bookings",
                column: "GuestPictureUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_UserPicture64_GuestPictureUserId",
                table: "Bookings",
                column: "GuestPictureUserId",
                principalTable: "UserPicture64",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_UserPicture64_GuestPictureUserId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_GuestPictureUserId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "GuestPictureUserId",
                table: "Bookings");
        }
    }
}
