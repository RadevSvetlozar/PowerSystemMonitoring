using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerSystemMonitoring.Data.Migrations
{
    public partial class AddDatabaseModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    AddedByUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Areas_AspNetUsers_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AddedByUserId = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeographicalCoordinates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    AreaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeographicalCoordinates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeographicalCoordinates_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Conductors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Length = table.Column<double>(nullable: false),
                    OuterDiameter = table.Column<double>(nullable: false),
                    InnerDiameter = table.Column<double>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    RTCoefficient = table.Column<double>(nullable: false),
                    CoefficientOfThermalExpansion = table.Column<double>(nullable: false),
                    Elasticity = table.Column<double>(nullable: false),
                    Section = table.Column<double>(nullable: false),
                    MaxTemperature = table.Column<double>(nullable: false),
                    Current = table.Column<double>(nullable: false),
                    MaxCurrent = table.Column<double>(nullable: false),
                    ConductorPerPhase = table.Column<int>(nullable: false),
                    AddedByUserId = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    CurrentSensorId = table.Column<int>(nullable: false),
                    AreaId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conductors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conductors_AspNetUsers_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conductors_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conductors_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PowerLines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Length = table.Column<double>(nullable: false),
                    Voltage = table.Column<double>(nullable: false),
                    ConductorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PowerLines_Conductors_ConductorId",
                        column: x => x.ConductorId,
                        principalTable: "Conductors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PowerLinesAreas",
                columns: table => new
                {
                    PowerLineId = table.Column<int>(nullable: false),
                    AreaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerLinesAreas", x => new { x.PowerLineId, x.AreaId });
                    table.ForeignKey(
                        name: "FK_PowerLinesAreas_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PowerLinesAreas_PowerLines_PowerLineId",
                        column: x => x.PowerLineId,
                        principalTable: "PowerLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PowerLinesEvents",
                columns: table => new
                {
                    PowerLineId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerLinesEvents", x => new { x.PowerLineId, x.EventId });
                    table.ForeignKey(
                        name: "FK_PowerLinesEvents_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PowerLinesEvents_PowerLines_PowerLineId",
                        column: x => x.PowerLineId,
                        principalTable: "PowerLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CurrentSensors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    ConnectionPassword = table.Column<string>(nullable: true),
                    IPAddress = table.Column<string>(nullable: true),
                    InstallationHeight = table.Column<double>(nullable: false),
                    DistancePole = table.Column<double>(nullable: false),
                    Orientation = table.Column<double>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    AreaId = table.Column<int>(nullable: false),
                    ConductorId = table.Column<int>(nullable: false),
                    PowerLineId = table.Column<int>(nullable: false),
                    GeographicalCoordinatesId = table.Column<int>(nullable: false),
                    AddedByUserId = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    WeatherStationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentSensors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrentSensors_AspNetUsers_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurrentSensors_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurrentSensors_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurrentSensors_Conductors_ConductorId",
                        column: x => x.ConductorId,
                        principalTable: "Conductors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurrentSensors_GeographicalCoordinates_GeographicalCoordinatesId",
                        column: x => x.GeographicalCoordinatesId,
                        principalTable: "GeographicalCoordinates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurrentSensors_PowerLines_PowerLineId",
                        column: x => x.PowerLineId,
                        principalTable: "PowerLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CurrentSensorsEvents",
                columns: table => new
                {
                    CurrentSensorId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentSensorsEvents", x => new { x.CurrentSensorId, x.EventId });
                    table.ForeignKey(
                        name: "FK_CurrentSensorsEvents_CurrentSensors_CurrentSensorId",
                        column: x => x.CurrentSensorId,
                        principalTable: "CurrentSensors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurrentSensorsEvents_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Extension = table.Column<string>(nullable: true),
                    RemoteImageUrl = table.Column<string>(nullable: true),
                    AddedByUserId = table.Column<string>(nullable: true),
                    AreaId = table.Column<int>(nullable: true),
                    ConductorId = table.Column<int>(nullable: true),
                    CurrentSensorId = table.Column<int>(nullable: true),
                    WeatherStationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_AspNetUsers_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Images_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Images_Conductors_ConductorId",
                        column: x => x.ConductorId,
                        principalTable: "Conductors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Images_CurrentSensors_CurrentSensorId",
                        column: x => x.CurrentSensorId,
                        principalTable: "CurrentSensors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConductorsImages",
                columns: table => new
                {
                    ConductorId = table.Column<int>(nullable: false),
                    ImageId = table.Column<int>(nullable: false),
                    ImageId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConductorsImages", x => new { x.ConductorId, x.ImageId });
                    table.ForeignKey(
                        name: "FK_ConductorsImages_Conductors_ConductorId",
                        column: x => x.ConductorId,
                        principalTable: "Conductors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConductorsImages_Images_ImageId1",
                        column: x => x.ImageId1,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CurrentSensorsImages",
                columns: table => new
                {
                    CurrentSensorId = table.Column<int>(nullable: false),
                    ImageId = table.Column<int>(nullable: false),
                    ImageId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentSensorsImages", x => new { x.CurrentSensorId, x.ImageId });
                    table.ForeignKey(
                        name: "FK_CurrentSensorsImages_CurrentSensors_CurrentSensorId",
                        column: x => x.CurrentSensorId,
                        principalTable: "CurrentSensors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurrentSensorsImages_Images_ImageId1",
                        column: x => x.ImageId1,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeatherStations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    AddedByUserId = table.Column<string>(nullable: true),
                    GeographicalCoordinatesId = table.Column<int>(nullable: false),
                    IPAddress = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    InstalationDescription = table.Column<string>(nullable: true),
                    InstallationImageId = table.Column<string>(nullable: true),
                    DescriptionImageId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherStations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeatherStations_AspNetUsers_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeatherStations_Images_DescriptionImageId",
                        column: x => x.DescriptionImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeatherStations_GeographicalCoordinates_GeographicalCoordinatesId",
                        column: x => x.GeographicalCoordinatesId,
                        principalTable: "GeographicalCoordinates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeatherStations_Images_InstallationImageId",
                        column: x => x.InstallationImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeatherStationsImages",
                columns: table => new
                {
                    ImageId = table.Column<int>(nullable: false),
                    WeatherStationId = table.Column<int>(nullable: false),
                    ImageId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherStationsImages", x => new { x.WeatherStationId, x.ImageId });
                    table.ForeignKey(
                        name: "FK_WeatherStationsImages_Images_ImageId1",
                        column: x => x.ImageId1,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeatherStationsImages_WeatherStations_WeatherStationId",
                        column: x => x.WeatherStationId,
                        principalTable: "WeatherStations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Areas_AddedByUserId",
                table: "Areas",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_IsDeleted",
                table: "Areas",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_AddedByUserId",
                table: "Categories",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_IsDeleted",
                table: "Categories",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Conductors_AddedByUserId",
                table: "Conductors",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Conductors_AreaId",
                table: "Conductors",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Conductors_CategoryId",
                table: "Conductors",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Conductors_IsDeleted",
                table: "Conductors",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ConductorsImages_ImageId1",
                table: "ConductorsImages",
                column: "ImageId1");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentSensors_AddedByUserId",
                table: "CurrentSensors",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentSensors_AreaId",
                table: "CurrentSensors",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentSensors_CategoryId",
                table: "CurrentSensors",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentSensors_ConductorId",
                table: "CurrentSensors",
                column: "ConductorId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentSensors_GeographicalCoordinatesId",
                table: "CurrentSensors",
                column: "GeographicalCoordinatesId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentSensors_IsDeleted",
                table: "CurrentSensors",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentSensors_PowerLineId",
                table: "CurrentSensors",
                column: "PowerLineId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentSensors_WeatherStationId",
                table: "CurrentSensors",
                column: "WeatherStationId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentSensorsEvents_EventId",
                table: "CurrentSensorsEvents",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentSensorsImages_ImageId1",
                table: "CurrentSensorsImages",
                column: "ImageId1");

            migrationBuilder.CreateIndex(
                name: "IX_Events_IsDeleted",
                table: "Events",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_GeographicalCoordinates_AreaId",
                table: "GeographicalCoordinates",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_GeographicalCoordinates_IsDeleted",
                table: "GeographicalCoordinates",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Images_AddedByUserId",
                table: "Images",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_AreaId",
                table: "Images",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ConductorId",
                table: "Images",
                column: "ConductorId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_CurrentSensorId",
                table: "Images",
                column: "CurrentSensorId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_WeatherStationId",
                table: "Images",
                column: "WeatherStationId");

            migrationBuilder.CreateIndex(
                name: "IX_PowerLines_ConductorId",
                table: "PowerLines",
                column: "ConductorId");

            migrationBuilder.CreateIndex(
                name: "IX_PowerLines_IsDeleted",
                table: "PowerLines",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PowerLinesAreas_AreaId",
                table: "PowerLinesAreas",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_PowerLinesEvents_EventId",
                table: "PowerLinesEvents",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherStations_AddedByUserId",
                table: "WeatherStations",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherStations_DescriptionImageId",
                table: "WeatherStations",
                column: "DescriptionImageId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherStations_GeographicalCoordinatesId",
                table: "WeatherStations",
                column: "GeographicalCoordinatesId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherStations_InstallationImageId",
                table: "WeatherStations",
                column: "InstallationImageId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherStations_IsDeleted",
                table: "WeatherStations",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherStationsImages_ImageId1",
                table: "WeatherStationsImages",
                column: "ImageId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrentSensors_WeatherStations_WeatherStationId",
                table: "CurrentSensors",
                column: "WeatherStationId",
                principalTable: "WeatherStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_WeatherStations_WeatherStationId",
                table: "Images",
                column: "WeatherStationId",
                principalTable: "WeatherStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conductors_Areas_AreaId",
                table: "Conductors");

            migrationBuilder.DropForeignKey(
                name: "FK_CurrentSensors_Areas_AreaId",
                table: "CurrentSensors");

            migrationBuilder.DropForeignKey(
                name: "FK_GeographicalCoordinates_Areas_AreaId",
                table: "GeographicalCoordinates");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Areas_AreaId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Conductors_Categories_CategoryId",
                table: "Conductors");

            migrationBuilder.DropForeignKey(
                name: "FK_CurrentSensors_Categories_CategoryId",
                table: "CurrentSensors");

            migrationBuilder.DropForeignKey(
                name: "FK_CurrentSensors_Conductors_ConductorId",
                table: "CurrentSensors");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Conductors_ConductorId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_PowerLines_Conductors_ConductorId",
                table: "PowerLines");

            migrationBuilder.DropForeignKey(
                name: "FK_WeatherStations_Images_DescriptionImageId",
                table: "WeatherStations");

            migrationBuilder.DropForeignKey(
                name: "FK_WeatherStations_Images_InstallationImageId",
                table: "WeatherStations");

            migrationBuilder.DropTable(
                name: "ConductorsImages");

            migrationBuilder.DropTable(
                name: "CurrentSensorsEvents");

            migrationBuilder.DropTable(
                name: "CurrentSensorsImages");

            migrationBuilder.DropTable(
                name: "PowerLinesAreas");

            migrationBuilder.DropTable(
                name: "PowerLinesEvents");

            migrationBuilder.DropTable(
                name: "WeatherStationsImages");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Conductors");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "CurrentSensors");

            migrationBuilder.DropTable(
                name: "PowerLines");

            migrationBuilder.DropTable(
                name: "WeatherStations");

            migrationBuilder.DropTable(
                name: "GeographicalCoordinates");
        }
    }
}
