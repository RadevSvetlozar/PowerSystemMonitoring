namespace PowerSystemMonitoring.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RemoveAreaFromConductor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conductors_Areas_AreaId",
                table: "Conductors");

            migrationBuilder.DropIndex(
                name: "IX_Conductors_AreaId",
                table: "Conductors");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "Conductors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "Conductors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Conductors_AreaId",
                table: "Conductors",
                column: "AreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conductors_Areas_AreaId",
                table: "Conductors",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
