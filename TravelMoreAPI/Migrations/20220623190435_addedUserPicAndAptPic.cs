using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelMoreAPI.Migrations
{
    public partial class addedUserPicAndAptPic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageBase64",
                table: "Apartments");

            migrationBuilder.AddColumn<byte[]>(
                name: "UserPicture",
                table: "Users",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ApartmentPicture",
                table: "Apartments",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserPicture",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ApartmentPicture",
                table: "Apartments");

            migrationBuilder.AddColumn<string>(
                name: "ImageBase64",
                table: "Apartments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
