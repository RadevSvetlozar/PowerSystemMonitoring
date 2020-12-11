using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerSystemMonitoring.Data.Migrations
{
    public partial class UpdateEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddedByUserId",
                table: "PowerLines",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddedByUserId",
                table: "GeographicalCoordinates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddedByUserId",
                table: "Events",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PowerLines_AddedByUserId",
                table: "PowerLines",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GeographicalCoordinates_AddedByUserId",
                table: "GeographicalCoordinates",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_AddedByUserId",
                table: "Events",
                column: "AddedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_AddedByUserId",
                table: "Events",
                column: "AddedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GeographicalCoordinates_AspNetUsers_AddedByUserId",
                table: "GeographicalCoordinates",
                column: "AddedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PowerLines_AspNetUsers_AddedByUserId",
                table: "PowerLines",
                column: "AddedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_AddedByUserId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_GeographicalCoordinates_AspNetUsers_AddedByUserId",
                table: "GeographicalCoordinates");

            migrationBuilder.DropForeignKey(
                name: "FK_PowerLines_AspNetUsers_AddedByUserId",
                table: "PowerLines");

            migrationBuilder.DropIndex(
                name: "IX_PowerLines_AddedByUserId",
                table: "PowerLines");

            migrationBuilder.DropIndex(
                name: "IX_GeographicalCoordinates_AddedByUserId",
                table: "GeographicalCoordinates");

            migrationBuilder.DropIndex(
                name: "IX_Events_AddedByUserId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "AddedByUserId",
                table: "PowerLines");

            migrationBuilder.DropColumn(
                name: "AddedByUserId",
                table: "GeographicalCoordinates");

            migrationBuilder.DropColumn(
                name: "AddedByUserId",
                table: "Events");
        }
    }
}
