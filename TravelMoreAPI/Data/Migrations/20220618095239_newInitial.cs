using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelMoreAPI.Data.Migrations
{
    public partial class newInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Users_UserId",
                table: "Apartments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Apartments",
                table: "Apartments");

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "UserId",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("208faa1b-22a9-48c5-8a64-3f6153d8eb2c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("27b6885d-55a5-4e30-8acf-08b9c94681fb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("73d73af1-053e-4562-ba24-84bfd2148af1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("f000d5fa-8d40-4dc6-926d-490ee97e59ff"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Apartments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Apartments",
                table: "Apartments",
                column: "ApartmentId");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApartmentId", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("13e00f59-135b-49f9-9be6-aacac0e35339"), null, "tuga@in.pl", "Alex", "Salvado", new byte[] { 235, 35, 132, 76, 45, 217, 38, 64, 185, 254, 50, 60, 219, 138, 180, 254, 9, 73, 251, 118, 49, 210, 187, 48, 151, 164, 197, 12, 150, 246, 61, 120, 146, 152, 64, 17, 69, 48, 11, 180, 221, 161, 203, 128, 206, 110, 220, 189, 218, 78, 105, 125, 187, 177, 101, 51, 174, 182, 237, 10, 40, 61, 250, 150 }, new byte[] { 223, 72, 245, 22, 70, 21, 4, 137, 155, 23, 236, 183, 121, 193, 120, 78, 101, 88, 217, 189, 230, 216, 245, 88, 23, 123, 121, 244, 142, 169, 177, 17, 89, 99, 81, 157, 192, 249, 178, 230, 45, 75, 17, 36, 212, 179, 208, 67, 155, 7, 41, 103, 75, 38, 99, 203, 92, 8, 50, 247, 229, 147, 126, 146, 119, 160, 5, 127, 35, 184, 199, 174, 40, 203, 146, 102, 194, 159, 171, 238, 154, 168, 59, 231, 158, 188, 74, 228, 109, 109, 239, 153, 206, 191, 248, 145, 246, 49, 104, 23, 67, 195, 33, 107, 163, 99, 47, 156, 155, 169, 41, 48, 37, 99, 117, 41, 241, 90, 207, 145, 221, 44, 91, 136, 137, 167, 213, 29 }, "tuga" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApartmentId", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("9595ecbe-818d-4507-b82b-a9d1fa6d1a90"), null, "test@user.co", "Test", "User", new byte[] { 235, 35, 132, 76, 45, 217, 38, 64, 185, 254, 50, 60, 219, 138, 180, 254, 9, 73, 251, 118, 49, 210, 187, 48, 151, 164, 197, 12, 150, 246, 61, 120, 146, 152, 64, 17, 69, 48, 11, 180, 221, 161, 203, 128, 206, 110, 220, 189, 218, 78, 105, 125, 187, 177, 101, 51, 174, 182, 237, 10, 40, 61, 250, 150 }, new byte[] { 223, 72, 245, 22, 70, 21, 4, 137, 155, 23, 236, 183, 121, 193, 120, 78, 101, 88, 217, 189, 230, 216, 245, 88, 23, 123, 121, 244, 142, 169, 177, 17, 89, 99, 81, 157, 192, 249, 178, 230, 45, 75, 17, 36, 212, 179, 208, 67, 155, 7, 41, 103, 75, 38, 99, 203, 92, 8, 50, 247, 229, 147, 126, 146, 119, 160, 5, 127, 35, 184, 199, 174, 40, 203, 146, 102, 194, 159, 171, 238, 154, 168, 59, 231, 158, 188, 74, 228, 109, 109, 239, 153, 206, 191, 248, 145, 246, 49, 104, 23, 67, 195, 33, 107, 163, 99, 47, 156, 155, 169, 41, 48, 37, 99, 117, 41, 241, 90, 207, 145, 221, 44, 91, 136, 137, 167, 213, 29 }, "testuser" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ApartmentId",
                table: "Users",
                column: "ApartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Apartments_ApartmentId",
                table: "Users",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "ApartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Apartments_ApartmentId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ApartmentId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Apartments",
                table: "Apartments");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("13e00f59-135b-49f9-9be6-aacac0e35339"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("9595ecbe-818d-4507-b82b-a9d1fa6d1a90"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Apartments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Apartments",
                table: "Apartments",
                column: "UserId");

            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "UserId", "Address", "ApartmentId", "BedsNumber", "City", "DistanceToCenter", "ImageBase64" },
                values: new object[] { new Guid("208faa1b-22a9-48c5-8a64-3f6153d8eb2c"), "panaskerteli 7", new Guid("94afc61e-6ea9-4331-8ce7-f6cb16be7792"), 3, "Tbilisi", 2, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApartmentId", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "UserName" },
                values: new object[,]
                {
                    { new Guid("27b6885d-55a5-4e30-8acf-08b9c94681fb"), null, "test@user.co", "Test", "User", new byte[] { 235, 35, 132, 76, 45, 217, 38, 64, 185, 254, 50, 60, 219, 138, 180, 254, 9, 73, 251, 118, 49, 210, 187, 48, 151, 164, 197, 12, 150, 246, 61, 120, 146, 152, 64, 17, 69, 48, 11, 180, 221, 161, 203, 128, 206, 110, 220, 189, 218, 78, 105, 125, 187, 177, 101, 51, 174, 182, 237, 10, 40, 61, 250, 150 }, new byte[] { 223, 72, 245, 22, 70, 21, 4, 137, 155, 23, 236, 183, 121, 193, 120, 78, 101, 88, 217, 189, 230, 216, 245, 88, 23, 123, 121, 244, 142, 169, 177, 17, 89, 99, 81, 157, 192, 249, 178, 230, 45, 75, 17, 36, 212, 179, 208, 67, 155, 7, 41, 103, 75, 38, 99, 203, 92, 8, 50, 247, 229, 147, 126, 146, 119, 160, 5, 127, 35, 184, 199, 174, 40, 203, 146, 102, 194, 159, 171, 238, 154, 168, 59, 231, 158, 188, 74, 228, 109, 109, 239, 153, 206, 191, 248, 145, 246, 49, 104, 23, 67, 195, 33, 107, 163, 99, 47, 156, 155, 169, 41, 48, 37, 99, 117, 41, 241, 90, 207, 145, 221, 44, 91, 136, 137, 167, 213, 29 }, "testuser" },
                    { new Guid("73d73af1-053e-4562-ba24-84bfd2148af1"), null, "n_gurchiani@cu.edu.ge", "Nicolas", "Gurchiani", new byte[] { 235, 35, 132, 76, 45, 217, 38, 64, 185, 254, 50, 60, 219, 138, 180, 254, 9, 73, 251, 118, 49, 210, 187, 48, 151, 164, 197, 12, 150, 246, 61, 120, 146, 152, 64, 17, 69, 48, 11, 180, 221, 161, 203, 128, 206, 110, 220, 189, 218, 78, 105, 125, 187, 177, 101, 51, 174, 182, 237, 10, 40, 61, 250, 150 }, new byte[] { 223, 72, 245, 22, 70, 21, 4, 137, 155, 23, 236, 183, 121, 193, 120, 78, 101, 88, 217, 189, 230, 216, 245, 88, 23, 123, 121, 244, 142, 169, 177, 17, 89, 99, 81, 157, 192, 249, 178, 230, 45, 75, 17, 36, 212, 179, 208, 67, 155, 7, 41, 103, 75, 38, 99, 203, 92, 8, 50, 247, 229, 147, 126, 146, 119, 160, 5, 127, 35, 184, 199, 174, 40, 203, 146, 102, 194, 159, 171, 238, 154, 168, 59, 231, 158, 188, 74, 228, 109, 109, 239, 153, 206, 191, 248, 145, 246, 49, 104, 23, 67, 195, 33, 107, 163, 99, 47, 156, 155, 169, 41, 48, 37, 99, 117, 41, 241, 90, 207, 145, 221, 44, 91, 136, 137, 167, 213, 29 }, "vbaar" },
                    { new Guid("f000d5fa-8d40-4dc6-926d-490ee97e59ff"), null, "tuga@in.pl", "Alex", "Salvado", new byte[] { 235, 35, 132, 76, 45, 217, 38, 64, 185, 254, 50, 60, 219, 138, 180, 254, 9, 73, 251, 118, 49, 210, 187, 48, 151, 164, 197, 12, 150, 246, 61, 120, 146, 152, 64, 17, 69, 48, 11, 180, 221, 161, 203, 128, 206, 110, 220, 189, 218, 78, 105, 125, 187, 177, 101, 51, 174, 182, 237, 10, 40, 61, 250, 150 }, new byte[] { 223, 72, 245, 22, 70, 21, 4, 137, 155, 23, 236, 183, 121, 193, 120, 78, 101, 88, 217, 189, 230, 216, 245, 88, 23, 123, 121, 244, 142, 169, 177, 17, 89, 99, 81, 157, 192, 249, 178, 230, 45, 75, 17, 36, 212, 179, 208, 67, 155, 7, 41, 103, 75, 38, 99, 203, 92, 8, 50, 247, 229, 147, 126, 146, 119, 160, 5, 127, 35, 184, 199, 174, 40, 203, 146, 102, 194, 159, 171, 238, 154, 168, 59, 231, 158, 188, 74, 228, 109, 109, 239, 153, 206, 191, 248, 145, 246, 49, 104, 23, 67, 195, 33, 107, 163, 99, 47, 156, 155, 169, 41, 48, 37, 99, 117, 41, 241, 90, 207, 145, 221, 44, 91, 136, 137, 167, 213, 29 }, "tuga" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Users_UserId",
                table: "Apartments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
