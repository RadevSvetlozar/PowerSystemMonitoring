using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerSystemMonitoring.Data.Migrations
{
    public partial class UpdateEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RealTimeValues_CurrentSensorId",
                table: "RealTimeValues");

            migrationBuilder.AddColumn<int>(
                name: "RealTimeValuesId",
                table: "CurrentSensors",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RealTimeValues_CurrentSensorId",
                table: "RealTimeValues",
                column: "CurrentSensorId",
                unique: true,
                filter: "[CurrentSensorId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RealTimeValues_CurrentSensorId",
                table: "RealTimeValues");

            migrationBuilder.DropColumn(
                name: "RealTimeValuesId",
                table: "CurrentSensors");

            migrationBuilder.CreateIndex(
                name: "IX_RealTimeValues_CurrentSensorId",
                table: "RealTimeValues",
                column: "CurrentSensorId");
        }
    }
}
