using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Psysup.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixedTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppliedDoctorApplication_Applications_ApplicationId",
                table: "AppliedDoctorApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_AppliedDoctorApplication_Users_DoctorId",
                table: "AppliedDoctorApplication");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppliedDoctorApplication",
                table: "AppliedDoctorApplication");

            migrationBuilder.RenameTable(
                name: "AppliedDoctorApplication",
                newName: "AppliedDoctorApplications");

            migrationBuilder.RenameIndex(
                name: "IX_AppliedDoctorApplication_ApplicationId",
                table: "AppliedDoctorApplications",
                newName: "IX_AppliedDoctorApplications_ApplicationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppliedDoctorApplications",
                table: "AppliedDoctorApplications",
                columns: new[] { "DoctorId", "ApplicationId" });

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppliedDoctorApplications",
                table: "AppliedDoctorApplications");

            migrationBuilder.RenameTable(
                name: "AppliedDoctorApplications",
                newName: "AppliedDoctorApplication");

            migrationBuilder.RenameIndex(
                name: "IX_AppliedDoctorApplications_ApplicationId",
                table: "AppliedDoctorApplication",
                newName: "IX_AppliedDoctorApplication_ApplicationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppliedDoctorApplication",
                table: "AppliedDoctorApplication",
                columns: new[] { "DoctorId", "ApplicationId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AppliedDoctorApplication_Applications_ApplicationId",
                table: "AppliedDoctorApplication",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppliedDoctorApplication_Users_DoctorId",
                table: "AppliedDoctorApplication",
                column: "DoctorId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
