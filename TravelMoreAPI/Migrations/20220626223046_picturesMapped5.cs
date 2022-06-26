using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelMoreAPI.Migrations
{
    public partial class picturesMapped5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "ImageBase64",
                newName: "UserPicture");

            migrationBuilder.RenameColumn(
                name: "Header",
                table: "ImageBase64",
                newName: "UserHeader");

            migrationBuilder.AddColumn<string>(
                name: "ApartmentHeader",
                table: "ImageBase64",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "ApartmentPicture",
                table: "ImageBase64",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApartmentHeader",
                table: "ImageBase64");

            migrationBuilder.DropColumn(
                name: "ApartmentPicture",
                table: "ImageBase64");

            migrationBuilder.RenameColumn(
                name: "UserPicture",
                table: "ImageBase64",
                newName: "Picture");

            migrationBuilder.RenameColumn(
                name: "UserHeader",
                table: "ImageBase64",
                newName: "Header");
        }
    }
}
