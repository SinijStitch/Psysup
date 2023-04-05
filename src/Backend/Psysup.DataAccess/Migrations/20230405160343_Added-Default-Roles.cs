using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Psysup.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("05aab560-b9c7-4458-9642-2ba1a3a83237"), "User" },
                    { new Guid("28cd0a64-9c83-45d9-8fc3-bd7883fb7376"), "Doctor" },
                    { new Guid("86a8803f-569d-4f6e-9433-7dfccbf79ec2"), "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("05aab560-b9c7-4458-9642-2ba1a3a83237"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("28cd0a64-9c83-45d9-8fc3-bd7883fb7376"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("86a8803f-569d-4f6e-9433-7dfccbf79ec2"));
        }
    }
}
