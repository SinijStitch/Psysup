using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Psysup.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedIndexForCategoryNameAndDefaultAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "RoleUser",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "RoleUser",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ApplicationCategories",
                columns: table => new
                {
                    CategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationCategories", x => new { x.ApplicationId, x.CategoriesId });
                    table.ForeignKey(
                        name: "FK_ApplicationCategories_Applications_ApplicationsId",
                        column: x => x.ApplicationsId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationCategories_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash" },
                values: new object[] { new Guid("fda48c05-48b8-4655-b1e5-f0d707568ee3"), "psysadmin@gmail.com", "$2b$10$u9qwtAmulUGnGH3fWiH3/ujpTuQYbOcJUj0EDvd/xYW8nueUjwdAK" });

            migrationBuilder.InsertData(
                table: "RoleUser",
                columns: new[] { "RolesId", "UsersId", "RoleId", "UserId" },
                values: new object[] { new Guid("86a8803f-569d-4f6e-9433-7dfccbf79ec2"), new Guid("fda48c05-48b8-4655-b1e5-f0d707568ee3"), null, null });

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_RoleId",
                table: "RoleUser",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_UserId",
                table: "RoleUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationCategories_ApplicationsId",
                table: "ApplicationCategories",
                column: "ApplicationsId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationCategories_CategoriesId",
                table: "ApplicationCategories",
                column: "CategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_Roles_RoleId",
                table: "RoleUser",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_Users_UserId",
                table: "RoleUser",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_Roles_RoleId",
                table: "RoleUser");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_Users_UserId",
                table: "RoleUser");

            migrationBuilder.DropTable(
                name: "ApplicationCategories");

            migrationBuilder.DropIndex(
                name: "IX_RoleUser_RoleId",
                table: "RoleUser");

            migrationBuilder.DropIndex(
                name: "IX_RoleUser_UserId",
                table: "RoleUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Name",
                table: "Categories");

            migrationBuilder.DeleteData(
                table: "RoleUser",
                keyColumns: new[] { "RolesId", "UsersId" },
                keyValues: new object[] { new Guid("86a8803f-569d-4f6e-9433-7dfccbf79ec2"), new Guid("fda48c05-48b8-4655-b1e5-f0d707568ee3") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fda48c05-48b8-4655-b1e5-f0d707568ee3"));

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "RoleUser");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RoleUser");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ApplicationCategory",
                columns: table => new
                {
                    ApplicationsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationCategory", x => new { x.ApplicationsId, x.CategoriesId });
                    table.ForeignKey(
                        name: "FK_ApplicationCategory_Applications_ApplicationsId",
                        column: x => x.ApplicationsId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationCategory_Category_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationCategory_CategoriesId",
                table: "ApplicationCategory",
                column: "CategoriesId");
        }
    }
}
