using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelMoreAPI.Migrations
{
    public partial class separatedPictureDatabases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ApartmentPicture64",
                columns: table => new
                {
                    ApartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApartmentPicture = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ApartmentHeader = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentPicture64", x => x.ApartmentId);
                    table.ForeignKey(
                        name: "FK_ApartmentPicture64_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "ApartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPicture64",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserPicture = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    UserHeader = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPicture64", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserPicture64_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApartmentPicture64");

            migrationBuilder.DropTable(
                name: "UserPicture64");

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
                    ApartmentHeader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApartmentPicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    UserHeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPicture = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
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
    }
}
