namespace PowerSystemMonitoring.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RemoveCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conductors_Categories_CategoryId",
                table: "Conductors");

            migrationBuilder.DropForeignKey(
                name: "FK_CurrentSensors_Categories_CategoryId",
                table: "CurrentSensors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_CurrentSensors_CategoryId",
                table: "CurrentSensors");

            migrationBuilder.DropIndex(
                name: "IX_Conductors_CategoryId",
                table: "Conductors");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "CurrentSensors");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Conductors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "CurrentSensors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Conductors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_AspNetUsers_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrentSensors_CategoryId",
                table: "CurrentSensors",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Conductors_CategoryId",
                table: "Conductors",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_AddedByUserId",
                table: "Categories",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_IsDeleted",
                table: "Categories",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_Conductors_Categories_CategoryId",
                table: "Conductors",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CurrentSensors_Categories_CategoryId",
                table: "CurrentSensors",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
