using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class gpt_chat_table_post_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "GptChats",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GptChats_PostId",
                table: "GptChats",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_GptChats_Posts_PostId",
                table: "GptChats",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GptChats_Posts_PostId",
                table: "GptChats");

            migrationBuilder.DropIndex(
                name: "IX_GptChats_PostId",
                table: "GptChats");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "GptChats");
        }
    }
}
