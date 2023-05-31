using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Psysup.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PossibleModelsFix1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppliedDoctorApplications_Applications_ApplicationId",
                table: "AppliedDoctorApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_AppliedDoctorApplications_Users_DoctorId",
                table: "AppliedDoctorApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatUsers_Chats_ChatId",
                table: "ChatUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatUsers_Users_UserId",
                table: "ChatUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_AppliedDoctorApplications_Applications_ApplicationId",
                table: "AppliedDoctorApplications",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppliedDoctorApplications_Users_DoctorId",
                table: "AppliedDoctorApplications",
                column: "DoctorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatUsers_Chats_ChatId",
                table: "ChatUsers",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatUsers_Users_UserId",
                table: "ChatUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppliedDoctorApplications_Applications_ApplicationId",
                table: "AppliedDoctorApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_AppliedDoctorApplications_Users_DoctorId",
                table: "AppliedDoctorApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatUsers_Chats_ChatId",
                table: "ChatUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatUsers_Users_UserId",
                table: "ChatUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_AppliedDoctorApplications_Applications_ApplicationId",
                table: "AppliedDoctorApplications",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppliedDoctorApplications_Users_DoctorId",
                table: "AppliedDoctorApplications",
                column: "DoctorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatUsers_Chats_ChatId",
                table: "ChatUsers",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatUsers_Users_UserId",
                table: "ChatUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
