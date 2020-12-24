using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerSystemMonitoring.Data.Migrations
{
    public partial class AddRealTimeValuesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RealTimeValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CurrentSensorId = table.Column<int>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    Current = table.Column<float>(nullable: false),
                    Temparature = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealTimeValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealTimeValues_CurrentSensors_CurrentSensorId",
                        column: x => x.CurrentSensorId,
                        principalTable: "CurrentSensors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RealTimeValues_CurrentSensorId",
                table: "RealTimeValues",
                column: "CurrentSensorId");

            migrationBuilder.CreateIndex(
                name: "IX_RealTimeValues_IsDeleted",
                table: "RealTimeValues",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RealTimeValues");
        }
    }
}
