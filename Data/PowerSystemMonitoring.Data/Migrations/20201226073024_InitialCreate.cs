namespace PowerSystemMonitoring.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
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
                    Name = table.Column<string>(maxLength: 30, nullable: false),
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
                    ImageId = table.Column<string>(nullable: true)
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
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Length = table.Column<double>(nullable: false),
                    Voltage = table.Column<double>(nullable: false),
                    ConductorId = table.Column<int>(nullable: true),
                    ImageId = table.Column<int>(nullable: true),
                    AddedByUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PowerLines_AspNetUsers_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PowerLines_Conductors_ConductorId",
                        column: x => x.ConductorId,
                        principalTable: "Conductors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    AddedByUserId = table.Column<string>(nullable: true),
                    PowerLineId = table.Column<int>(nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Areas_PowerLines_PowerLineId",
                        column: x => x.PowerLineId,
                        principalTable: "PowerLines",
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
                name: "CurrentSensors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    Model = table.Column<string>(maxLength: 20, nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    ConnectionPassword = table.Column<string>(nullable: false),
                    IPAddress = table.Column<string>(maxLength: 15, nullable: false),
                    InstallationHeight = table.Column<double>(nullable: false),
                    DistancePole = table.Column<double>(nullable: false),
                    Orientation = table.Column<double>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    AreaId = table.Column<int>(nullable: true),
                    PowerLineId = table.Column<int>(nullable: true),
                    RealTimeValuesId = table.Column<int>(nullable: true),
                    GeographicalCoordinatesId = table.Column<int>(nullable: true),
                    AddedByUserId = table.Column<string>(nullable: true),
                    WeatherStationId = table.Column<int>(nullable: true),
                    ImageId = table.Column<string>(nullable: true)
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
                        name: "FK_CurrentSensors_PowerLines_PowerLineId",
                        column: x => x.PowerLineId,
                        principalTable: "PowerLines",
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
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CurrentSensorId = table.Column<int>(nullable: true),
                    AddedByUserId = table.Column<string>(nullable: true),
                    PowerLineId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_AspNetUsers_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_CurrentSensors_CurrentSensorId",
                        column: x => x.CurrentSensorId,
                        principalTable: "CurrentSensors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_PowerLines_PowerLineId",
                        column: x => x.PowerLineId,
                        principalTable: "PowerLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Latitude = table.Column<string>(nullable: false),
                    Longitude = table.Column<string>(nullable: false),
                    AddedByUserId = table.Column<string>(nullable: true),
                    CurrentSensorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeographicalCoordinates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeographicalCoordinates_AspNetUsers_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GeographicalCoordinates_CurrentSensors_CurrentSensorId",
                        column: x => x.CurrentSensorId,
                        principalTable: "CurrentSensors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    Temperature = table.Column<double>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    IPAddress = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    InstalationDescription = table.Column<string>(nullable: true),
                    AddedByUserId = table.Column<string>(nullable: true),
                    GeographicalCoordinatesId = table.Column<int>(nullable: true)
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
                        name: "FK_WeatherStations_GeographicalCoordinates_GeographicalCoordinatesId",
                        column: x => x.GeographicalCoordinatesId,
                        principalTable: "GeographicalCoordinates",
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
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Extension = table.Column<string>(nullable: true),
                    RemoteImageUrl = table.Column<string>(nullable: true),
                    AddedByUserId = table.Column<string>(nullable: true),
                    ConductorId = table.Column<int>(nullable: true),
                    CurrentSensorId = table.Column<int>(nullable: true),
                    WeatherStationId = table.Column<int>(nullable: true),
                    AreaId = table.Column<int>(nullable: true),
                    PowerLineId = table.Column<int>(nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Images_PowerLines_PowerLineId",
                        column: x => x.PowerLineId,
                        principalTable: "PowerLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Images_WeatherStations_WeatherStationId",
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
                name: "IX_Areas_PowerLineId",
                table: "Areas",
                column: "PowerLineId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_IsDeleted",
                table: "AspNetRoles",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IsDeleted",
                table: "AspNetUsers",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Conductors_AddedByUserId",
                table: "Conductors",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Conductors_IsDeleted",
                table: "Conductors",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentSensors_AddedByUserId",
                table: "CurrentSensors",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentSensors_AreaId",
                table: "CurrentSensors",
                column: "AreaId");

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
                name: "IX_Events_AddedByUserId",
                table: "Events",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CurrentSensorId",
                table: "Events",
                column: "CurrentSensorId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_IsDeleted",
                table: "Events",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Events_PowerLineId",
                table: "Events",
                column: "PowerLineId");

            migrationBuilder.CreateIndex(
                name: "IX_GeographicalCoordinates_AddedByUserId",
                table: "GeographicalCoordinates",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GeographicalCoordinates_CurrentSensorId",
                table: "GeographicalCoordinates",
                column: "CurrentSensorId",
                unique: true,
                filter: "[CurrentSensorId] IS NOT NULL");

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
                column: "AreaId",
                unique: true,
                filter: "[AreaId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ConductorId",
                table: "Images",
                column: "ConductorId",
                unique: true,
                filter: "[ConductorId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Images_CurrentSensorId",
                table: "Images",
                column: "CurrentSensorId",
                unique: true,
                filter: "[CurrentSensorId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Images_IsDeleted",
                table: "Images",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Images_PowerLineId",
                table: "Images",
                column: "PowerLineId",
                unique: true,
                filter: "[PowerLineId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Images_WeatherStationId",
                table: "Images",
                column: "WeatherStationId",
                unique: true,
                filter: "[WeatherStationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PowerLines_AddedByUserId",
                table: "PowerLines",
                column: "AddedByUserId");

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
                name: "IX_RealTimeValues_CurrentSensorId",
                table: "RealTimeValues",
                column: "CurrentSensorId",
                unique: true,
                filter: "[CurrentSensorId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RealTimeValues_IsDeleted",
                table: "RealTimeValues",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherStations_AddedByUserId",
                table: "WeatherStations",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherStations_GeographicalCoordinatesId",
                table: "WeatherStations",
                column: "GeographicalCoordinatesId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherStations_IsDeleted",
                table: "WeatherStations",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrentSensors_WeatherStations_WeatherStationId",
                table: "CurrentSensors",
                column: "WeatherStationId",
                principalTable: "WeatherStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_AspNetUsers_AddedByUserId",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_Conductors_AspNetUsers_AddedByUserId",
                table: "Conductors");

            migrationBuilder.DropForeignKey(
                name: "FK_CurrentSensors_AspNetUsers_AddedByUserId",
                table: "CurrentSensors");

            migrationBuilder.DropForeignKey(
                name: "FK_GeographicalCoordinates_AspNetUsers_AddedByUserId",
                table: "GeographicalCoordinates");

            migrationBuilder.DropForeignKey(
                name: "FK_PowerLines_AspNetUsers_AddedByUserId",
                table: "PowerLines");

            migrationBuilder.DropForeignKey(
                name: "FK_WeatherStations_AspNetUsers_AddedByUserId",
                table: "WeatherStations");

            migrationBuilder.DropForeignKey(
                name: "FK_Areas_PowerLines_PowerLineId",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_CurrentSensors_PowerLines_PowerLineId",
                table: "CurrentSensors");

            migrationBuilder.DropForeignKey(
                name: "FK_CurrentSensors_Areas_AreaId",
                table: "CurrentSensors");

            migrationBuilder.DropForeignKey(
                name: "FK_CurrentSensors_WeatherStations_WeatherStationId",
                table: "CurrentSensors");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "PowerLinesAreas");

            migrationBuilder.DropTable(
                name: "RealTimeValues");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PowerLines");

            migrationBuilder.DropTable(
                name: "Conductors");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "WeatherStations");

            migrationBuilder.DropTable(
                name: "GeographicalCoordinates");

            migrationBuilder.DropTable(
                name: "CurrentSensors");
        }
    }
}
