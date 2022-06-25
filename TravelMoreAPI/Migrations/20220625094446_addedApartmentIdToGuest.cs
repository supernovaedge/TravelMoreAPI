using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelMoreAPI.Migrations
{
    public partial class addedApartmentIdToGuest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "Booking",
                newName: "ApartmentId");

            migrationBuilder.AddColumn<Guid>(
                name: "ApartmentID",
                table: "Guests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApartmentID",
                table: "Guests");

            migrationBuilder.RenameColumn(
                name: "ApartmentId",
                table: "Booking",
                newName: "BookingId");
        }
    }
}
