using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class fixuserprofile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAllergies_UserProfiles_UserId",
                table: "UserAllergies");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMedicalHistories_UserProfiles_UserId",
                table: "UserMedicalHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMedications_UserProfiles_UserId",
                table: "UserMedications");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAllergies_Users_UserId",
                table: "UserAllergies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMedicalHistories_Users_UserId",
                table: "UserMedicalHistories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMedications_Users_UserId",
                table: "UserMedications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAllergies_Users_UserId",
                table: "UserAllergies");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMedicalHistories_Users_UserId",
                table: "UserMedicalHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMedications_Users_UserId",
                table: "UserMedications");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAllergies_UserProfiles_UserId",
                table: "UserAllergies",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMedicalHistories_UserProfiles_UserId",
                table: "UserMedicalHistories",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMedications_UserProfiles_UserId",
                table: "UserMedications",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
