namespace PowerSystemMonitoring.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class UpdateCurrentSensorEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RealTimeValues_CurrentSensorId",
                table: "RealTimeValues");

            migrationBuilder.AddColumn<int>(
                name: "RealTimeValuesId",
                table: "CurrentSensors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RealTimeValues_CurrentSensorId",
                table: "RealTimeValues",
                column: "CurrentSensorId",
                unique: true,
                filter: "[CurrentSensorId] IS NOT NULL");
        }
    }
}
