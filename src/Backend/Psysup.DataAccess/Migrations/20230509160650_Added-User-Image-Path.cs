using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Psysup.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserImagePath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fda48c05-48b8-4655-b1e5-f0d707568ee3"),
                column: "ImagePath",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true)
                .Annotation("SqlServer:Include", new[] { "PasswordHash", "ImagePath" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true)
                .Annotation("SqlServer:Include", new[] { "PasswordHash" });
        }
    }
}
