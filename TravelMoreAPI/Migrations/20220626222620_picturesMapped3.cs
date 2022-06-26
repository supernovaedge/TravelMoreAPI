using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelMoreAPI.Migrations
{
    public partial class picturesMapped3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ApartmentPictureUserId",
                table: "Apartments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ImageBase64",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageBase64", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_ImageBase64_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_ApartmentPictureUserId",
                table: "Apartments",
                column: "ApartmentPictureUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_ImageBase64_ApartmentPictureUserId",
                table: "Apartments",
                column: "ApartmentPictureUserId",
                principalTable: "ImageBase64",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_ImageBase64_ApartmentPictureUserId",
                table: "Apartments");

            migrationBuilder.DropTable(
                name: "ImageBase64");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_ApartmentPictureUserId",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "ApartmentPictureUserId",
                table: "Apartments");
        }
    }
}
