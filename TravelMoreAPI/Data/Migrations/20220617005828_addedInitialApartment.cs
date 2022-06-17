using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelMoreAPI.Data.Migrations
{
    public partial class addedInitialApartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("785fad0d-f332-412c-8686-d38225581745"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("a1c95925-8b26-4468-bc2b-5141287008b8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("c2f1bafe-af3d-4420-be5c-a8b17fb6452e"));

            migrationBuilder.AlterColumn<string>(
                name: "ImageBase64",
                table: "Apartments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApartmentId", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("207e4d08-75ab-465c-8604-50e6b1316f79"), null, "n_gurchiani@cu.edu.ge", "Nicolas", "Gurchiani", new byte[] { 235, 35, 132, 76, 45, 217, 38, 64, 185, 254, 50, 60, 219, 138, 180, 254, 9, 73, 251, 118, 49, 210, 187, 48, 151, 164, 197, 12, 150, 246, 61, 120, 146, 152, 64, 17, 69, 48, 11, 180, 221, 161, 203, 128, 206, 110, 220, 189, 218, 78, 105, 125, 187, 177, 101, 51, 174, 182, 237, 10, 40, 61, 250, 150 }, new byte[] { 223, 72, 245, 22, 70, 21, 4, 137, 155, 23, 236, 183, 121, 193, 120, 78, 101, 88, 217, 189, 230, 216, 245, 88, 23, 123, 121, 244, 142, 169, 177, 17, 89, 99, 81, 157, 192, 249, 178, 230, 45, 75, 17, 36, 212, 179, 208, 67, 155, 7, 41, 103, 75, 38, 99, 203, 92, 8, 50, 247, 229, 147, 126, 146, 119, 160, 5, 127, 35, 184, 199, 174, 40, 203, 146, 102, 194, 159, 171, 238, 154, 168, 59, 231, 158, 188, 74, 228, 109, 109, 239, 153, 206, 191, 248, 145, 246, 49, 104, 23, 67, 195, 33, 107, 163, 99, 47, 156, 155, 169, 41, 48, 37, 99, 117, 41, 241, 90, 207, 145, 221, 44, 91, 136, 137, 167, 213, 29 }, "vbaar" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApartmentId", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("66f1809c-e7ed-497e-b4c7-3511aed81463"), null, "tuga@in.pl", "Alex", "Salvado", new byte[] { 235, 35, 132, 76, 45, 217, 38, 64, 185, 254, 50, 60, 219, 138, 180, 254, 9, 73, 251, 118, 49, 210, 187, 48, 151, 164, 197, 12, 150, 246, 61, 120, 146, 152, 64, 17, 69, 48, 11, 180, 221, 161, 203, 128, 206, 110, 220, 189, 218, 78, 105, 125, 187, 177, 101, 51, 174, 182, 237, 10, 40, 61, 250, 150 }, new byte[] { 223, 72, 245, 22, 70, 21, 4, 137, 155, 23, 236, 183, 121, 193, 120, 78, 101, 88, 217, 189, 230, 216, 245, 88, 23, 123, 121, 244, 142, 169, 177, 17, 89, 99, 81, 157, 192, 249, 178, 230, 45, 75, 17, 36, 212, 179, 208, 67, 155, 7, 41, 103, 75, 38, 99, 203, 92, 8, 50, 247, 229, 147, 126, 146, 119, 160, 5, 127, 35, 184, 199, 174, 40, 203, 146, 102, 194, 159, 171, 238, 154, 168, 59, 231, 158, 188, 74, 228, 109, 109, 239, 153, 206, 191, 248, 145, 246, 49, 104, 23, 67, 195, 33, 107, 163, 99, 47, 156, 155, 169, 41, 48, 37, 99, 117, 41, 241, 90, 207, 145, 221, 44, 91, 136, 137, 167, 213, 29 }, "tuga" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApartmentId", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("aed4f181-0553-421f-bec0-071f60f9c1dc"), null, "test@user.co", "Test", "User", new byte[] { 235, 35, 132, 76, 45, 217, 38, 64, 185, 254, 50, 60, 219, 138, 180, 254, 9, 73, 251, 118, 49, 210, 187, 48, 151, 164, 197, 12, 150, 246, 61, 120, 146, 152, 64, 17, 69, 48, 11, 180, 221, 161, 203, 128, 206, 110, 220, 189, 218, 78, 105, 125, 187, 177, 101, 51, 174, 182, 237, 10, 40, 61, 250, 150 }, new byte[] { 223, 72, 245, 22, 70, 21, 4, 137, 155, 23, 236, 183, 121, 193, 120, 78, 101, 88, 217, 189, 230, 216, 245, 88, 23, 123, 121, 244, 142, 169, 177, 17, 89, 99, 81, 157, 192, 249, 178, 230, 45, 75, 17, 36, 212, 179, 208, 67, 155, 7, 41, 103, 75, 38, 99, 203, 92, 8, 50, 247, 229, 147, 126, 146, 119, 160, 5, 127, 35, 184, 199, 174, 40, 203, 146, 102, 194, 159, 171, 238, 154, 168, 59, 231, 158, 188, 74, 228, 109, 109, 239, 153, 206, 191, 248, 145, 246, 49, 104, 23, 67, 195, 33, 107, 163, 99, 47, 156, 155, 169, 41, 48, 37, 99, 117, 41, 241, 90, 207, 145, 221, 44, 91, 136, 137, 167, 213, 29 }, "testuser" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("207e4d08-75ab-465c-8604-50e6b1316f79"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("66f1809c-e7ed-497e-b4c7-3511aed81463"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("aed4f181-0553-421f-bec0-071f60f9c1dc"));

            migrationBuilder.AlterColumn<string>(
                name: "ImageBase64",
                table: "Apartments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApartmentId", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("785fad0d-f332-412c-8686-d38225581745"), null, "tuga@in.pl", "Alex", "Salvado", new byte[] { 235, 35, 132, 76, 45, 217, 38, 64, 185, 254, 50, 60, 219, 138, 180, 254, 9, 73, 251, 118, 49, 210, 187, 48, 151, 164, 197, 12, 150, 246, 61, 120, 146, 152, 64, 17, 69, 48, 11, 180, 221, 161, 203, 128, 206, 110, 220, 189, 218, 78, 105, 125, 187, 177, 101, 51, 174, 182, 237, 10, 40, 61, 250, 150 }, new byte[] { 223, 72, 245, 22, 70, 21, 4, 137, 155, 23, 236, 183, 121, 193, 120, 78, 101, 88, 217, 189, 230, 216, 245, 88, 23, 123, 121, 244, 142, 169, 177, 17, 89, 99, 81, 157, 192, 249, 178, 230, 45, 75, 17, 36, 212, 179, 208, 67, 155, 7, 41, 103, 75, 38, 99, 203, 92, 8, 50, 247, 229, 147, 126, 146, 119, 160, 5, 127, 35, 184, 199, 174, 40, 203, 146, 102, 194, 159, 171, 238, 154, 168, 59, 231, 158, 188, 74, 228, 109, 109, 239, 153, 206, 191, 248, 145, 246, 49, 104, 23, 67, 195, 33, 107, 163, 99, 47, 156, 155, 169, 41, 48, 37, 99, 117, 41, 241, 90, 207, 145, 221, 44, 91, 136, 137, 167, 213, 29 }, "tuga" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApartmentId", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("a1c95925-8b26-4468-bc2b-5141287008b8"), null, "test@user.co", "Test", "User", new byte[] { 235, 35, 132, 76, 45, 217, 38, 64, 185, 254, 50, 60, 219, 138, 180, 254, 9, 73, 251, 118, 49, 210, 187, 48, 151, 164, 197, 12, 150, 246, 61, 120, 146, 152, 64, 17, 69, 48, 11, 180, 221, 161, 203, 128, 206, 110, 220, 189, 218, 78, 105, 125, 187, 177, 101, 51, 174, 182, 237, 10, 40, 61, 250, 150 }, new byte[] { 223, 72, 245, 22, 70, 21, 4, 137, 155, 23, 236, 183, 121, 193, 120, 78, 101, 88, 217, 189, 230, 216, 245, 88, 23, 123, 121, 244, 142, 169, 177, 17, 89, 99, 81, 157, 192, 249, 178, 230, 45, 75, 17, 36, 212, 179, 208, 67, 155, 7, 41, 103, 75, 38, 99, 203, 92, 8, 50, 247, 229, 147, 126, 146, 119, 160, 5, 127, 35, 184, 199, 174, 40, 203, 146, 102, 194, 159, 171, 238, 154, 168, 59, 231, 158, 188, 74, 228, 109, 109, 239, 153, 206, 191, 248, 145, 246, 49, 104, 23, 67, 195, 33, 107, 163, 99, 47, 156, 155, 169, 41, 48, 37, 99, 117, 41, 241, 90, 207, 145, 221, 44, 91, 136, 137, 167, 213, 29 }, "testuser" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApartmentId", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("c2f1bafe-af3d-4420-be5c-a8b17fb6452e"), null, "n_gurchiani@cu.edu.ge", "Nicolas", "Gurchiani", new byte[] { 235, 35, 132, 76, 45, 217, 38, 64, 185, 254, 50, 60, 219, 138, 180, 254, 9, 73, 251, 118, 49, 210, 187, 48, 151, 164, 197, 12, 150, 246, 61, 120, 146, 152, 64, 17, 69, 48, 11, 180, 221, 161, 203, 128, 206, 110, 220, 189, 218, 78, 105, 125, 187, 177, 101, 51, 174, 182, 237, 10, 40, 61, 250, 150 }, new byte[] { 223, 72, 245, 22, 70, 21, 4, 137, 155, 23, 236, 183, 121, 193, 120, 78, 101, 88, 217, 189, 230, 216, 245, 88, 23, 123, 121, 244, 142, 169, 177, 17, 89, 99, 81, 157, 192, 249, 178, 230, 45, 75, 17, 36, 212, 179, 208, 67, 155, 7, 41, 103, 75, 38, 99, 203, 92, 8, 50, 247, 229, 147, 126, 146, 119, 160, 5, 127, 35, 184, 199, 174, 40, 203, 146, 102, 194, 159, 171, 238, 154, 168, 59, 231, 158, 188, 74, 228, 109, 109, 239, 153, 206, 191, 248, 145, 246, 49, 104, 23, 67, 195, 33, 107, 163, 99, 47, 156, 155, 169, 41, 48, 37, 99, 117, 41, 241, 90, 207, 145, 221, 44, 91, 136, 137, 167, 213, 29 }, "vbaar" });
        }
    }
}
