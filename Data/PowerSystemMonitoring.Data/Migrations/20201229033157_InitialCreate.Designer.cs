﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PowerSystemMonitoring.Data;

namespace PowerSystemMonitoring.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201229033157_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("PowerSystemMonitoring.Data.Models.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("PowerSystemMonitoring.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("PowerSystemMonitoring.Data.Models.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddedByUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<int?>("PowerLineId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddedByUserId");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("PowerLineId");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("PowerSystemMonitoring.Data.Models.Conductor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddedByUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("CoefficientOfThermalExpansion")
                        .HasColumnType("float");

                    b.Property<int>("ConductorPerPhase")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<double>("Current")
                        .HasColumnType("float");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<double>("Elasticity")
                        .HasColumnType("float");

                    b.Property<string>("ImageId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("InnerDiameter")
                        .HasColumnType("float");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<double>("MaxCurrent")
                        .HasColumnType("float");

                    b.Property<double>("MaxTemperature")
                        .HasColumnType("float");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<double>("OuterDiameter")
                        .HasColumnType("float");

                    b.Property<double>("RTCoefficient")
                        .HasColumnType("float");

                    b.Property<double>("Section")
                        .HasColumnType("float");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AddedByUserId");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Conductors");
                });

            modelBuilder.Entity("PowerSystemMonitoring.Data.Models.CurrentSensor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddedByUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("AreaId")
                        .HasColumnType("int");

                    b.Property<string>("ConnectionPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<double>("DistancePole")
                        .HasColumnType("float");

                    b.Property<int?>("GeographicalCoordinatesId")
                        .HasColumnType("int");

                    b.Property<string>("IPAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("InstallationHeight")
                        .HasColumnType("float");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<double>("Orientation")
                        .HasColumnType("float");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PowerLineId")
                        .HasColumnType("int");

                    b.Property<int?>("WeatherStationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddedByUserId");

                    b.HasIndex("AreaId");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("PowerLineId");

                    b.HasIndex("WeatherStationId");

                    b.ToTable("CurrentSensors");
                });

            modelBuilder.Entity("PowerSystemMonitoring.Data.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddedByUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CurrentSensorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<int?>("PowerLineId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddedByUserId");

                    b.HasIndex("CurrentSensorId");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("PowerLineId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("PowerSystemMonitoring.Data.Models.GeographicalCoordinates", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddedByUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CurrentSensorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AddedByUserId");

                    b.HasIndex("CurrentSensorId")
                        .IsUnique()
                        .HasFilter("[CurrentSensorId] IS NOT NULL");

                    b.HasIndex("IsDeleted");

                    b.ToTable("GeographicalCoordinates");
                });

            modelBuilder.Entity("PowerSystemMonitoring.Data.Models.Image", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AddedByUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("AreaId")
                        .HasColumnType("int");

                    b.Property<int?>("ConductorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CurrentSensorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Extension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PowerLineId")
                        .HasColumnType("int");

                    b.Property<string>("RemoteImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WeatherStationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddedByUserId");

                    b.HasIndex("AreaId")
                        .IsUnique()
                        .HasFilter("[AreaId] IS NOT NULL");

                    b.HasIndex("ConductorId")
                        .IsUnique()
                        .HasFilter("[ConductorId] IS NOT NULL");

                    b.HasIndex("CurrentSensorId")
                        .IsUnique()
                        .HasFilter("[CurrentSensorId] IS NOT NULL");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("PowerLineId")
                        .IsUnique()
                        .HasFilter("[PowerLineId] IS NOT NULL");

                    b.HasIndex("WeatherStationId")
                        .IsUnique()
                        .HasFilter("[WeatherStationId] IS NOT NULL");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("PowerSystemMonitoring.Data.Models.PowerLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddedByUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("ConductorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<double>("Length")
                        .HasColumnType("float");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<double>("Voltage")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AddedByUserId");

                    b.HasIndex("ConductorId");

                    b.HasIndex("IsDeleted");

                    b.ToTable("PowerLines");
                });

            modelBuilder.Entity("PowerSystemMonitoring.Data.Models.PowerLinesAreas", b =>
                {
                    b.Property<int>("PowerLineId")
                        .HasColumnType("int");

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.HasKey("PowerLineId", "AreaId");

                    b.HasIndex("AreaId");

                    b.ToTable("PowerLinesAreas");
                });

            modelBuilder.Entity("PowerSystemMonitoring.Data.Models.RealTimeValues", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<float>("Current")
                        .HasColumnType("real");

                    b.Property<int?>("CurrentSensorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<float>("Temparature")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("CurrentSensorId");

                    b.HasIndex("IsDeleted");

                    b.ToTable("RealTimeValues");
                });

            modelBuilder.Entity("PowerSystemMonitoring.Data.Models.WeatherStation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddedByUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GeographicalCoordinatesId")
                        .HasColumnType("int");

                    b.Property<string>("IPAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstalationDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<double>("Temperature")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AddedByUserId");

                    b.HasIndex("GeographicalCoordinatesId");

                    b.HasIndex("IsDeleted");

                    b.ToTable("WeatherStations");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("PowerSystemMonitoring.Data.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("PowerSystemMonitoring.Data.Models.ApplicationUser", null)
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PowerSystemMonitoring.Data.Models.ApplicationUser", null)
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("PowerSystemMonitoring.Data.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PowerSystemMonitoring.Data.Models.ApplicationUser", null)
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PowerSystemMonitoring.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("PowerSystemMonitoring.Data.Models.Area", b =>
                {
                    b.HasOne("PowerSystemMonitoring.Data.Models.ApplicationUser", "AddedByUser")
                        .WithMany()
                        .HasForeignKey("AddedByUserId");

                    b.HasOne("PowerSystemMonitoring.Data.Models.PowerLine", null)
                        .WithMany("Areas")
                        .HasForeignKey("PowerLineId");
                });

            modelBuilder.Entity("PowerSystemMonitoring.Data.Models.Conductor", b =>
                {
                    b.HasOne("PowerSystemMonitoring.Data.Models.ApplicationUser", "AddedByUser")
                        .WithMany()
                        .HasForeignKey("AddedByUserId");
                });

            modelBuilder.Entity("PowerSystemMonitoring.Data.Models.CurrentSensor", b =>
                {
                    b.HasOne("PowerSystemMonitoring.Data.Models.ApplicationUser", "AddedByUser")
                        .WithMany()
                        .HasForeignKey("AddedByUserId");

                    b.HasOne("PowerSystemMonitoring.Data.Models.Area", "Area")
                        .WithMany("CurrentSensors")
                        .HasForeignKey("AreaId");

                    b.HasOne("PowerSystemMonitoring.Data.Models.PowerLine", "PowerLine")
                        .WithMany("CurrentSensors")
                        .HasForeignKey("PowerLineId");

                    b.HasOne("PowerSystemMonitoring.Data.Models.WeatherStation", "WeatherStation")
                        .WithMany("CurrentSensors")
                        .HasForeignKey("WeatherStationId");
                });

            modelBuilder.Entity("PowerSystemMonitoring.Data.Models.Event", b =>
                {
                    b.HasOne("PowerSystemMonitoring.Data.Models.ApplicationUser", "AddedByUser")
                        .WithMany()
                        .HasForeignKey("AddedByUserId");

                    b.HasOne("PowerSystemMonitoring.Data.Models.CurrentSensor", "CurrentSensor")
                        .WithMany("Events")
                        .HasForeignKey("CurrentSensorId");

                    b.HasOne("PowerSystemMonitoring.Data.Models.PowerLine", null)
                        .WithMany("Events")
                        .HasForeignKey("PowerLineId");
                });

            modelBuilder.Entity("PowerSystemMonitoring.Data.Models.GeographicalCoordinates", b =>
                {
                    b.HasOne("PowerSystemMonitoring.Data.Models.ApplicationUser", "AddedByUser")
                        .WithMany()
                        .HasForeignKey("AddedByUserId");

                    b.HasOne("PowerSystemMonitoring.Data.Models.CurrentSensor", "CurrentSensor")
                        .WithOne("GeographicalCoordinates")
                        .HasForeignKey("PowerSystemMonitoring.Data.Models.GeographicalCoordinates", "CurrentSensorId");
                });

            modelBuilder.Entity("PowerSystemMonitoring.Data.Models.Image", b =>
                {
                    b.HasOne("PowerSystemMonitoring.Data.Models.ApplicationUser", "AddedByUser")
                        .WithMany()
                        .HasForeignKey("AddedByUserId");

                    b.HasOne("PowerSystemMonitoring.Data.Models.Area", "Area")
                        .WithOne("Image")
                        .HasForeignKey("PowerSystemMonitoring.Data.Models.Image", "AreaId");

                    b.HasOne("PowerSystemMonitoring.Data.Models.Conductor", "Conductor")
                        .WithOne("Image")
                        .HasForeignKey("PowerSystemMonitoring.Data.Models.Image", "ConductorId");

                    b.HasOne("PowerSystemMonitoring.Data.Models.CurrentSensor", "CurrentSensor")
                        .WithOne("Image")
                        .HasForeignKey("PowerSystemMonitoring.Data.Models.Image", "CurrentSensorId");

                    b.HasOne("PowerSystemMonitoring.Data.Models.PowerLine", "PowerLine")
                        .WithOne("Image")
                        .HasForeignKey("PowerSystemMonitoring.Data.Models.Image", "PowerLineId");

                    b.HasOne("PowerSystemMonitoring.Data.Models.WeatherStation", "WeatherStation")
                        .WithOne("Image")
                        .HasForeignKey("PowerSystemMonitoring.Data.Models.Image", "WeatherStationId");
                });

            modelBuilder.Entity("PowerSystemMonitoring.Data.Models.PowerLine", b =>
                {
                    b.HasOne("PowerSystemMonitoring.Data.Models.ApplicationUser", "AddedByUser")
                        .WithMany()
                        .HasForeignKey("AddedByUserId");

                    b.HasOne("PowerSystemMonitoring.Data.Models.Conductor", "Conductor")
                        .WithMany("PowerLines")
                        .HasForeignKey("ConductorId");
                });

            modelBuilder.Entity("PowerSystemMonitoring.Data.Models.PowerLinesAreas", b =>
                {
                    b.HasOne("PowerSystemMonitoring.Data.Models.Area", "Area")
                        .WithMany("PowerLines")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PowerSystemMonitoring.Data.Models.PowerLine", "PowerLine")
                        .WithMany()
                        .HasForeignKey("PowerLineId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("PowerSystemMonitoring.Data.Models.RealTimeValues", b =>
                {
                    b.HasOne("PowerSystemMonitoring.Data.Models.CurrentSensor", "CurrentSensor")
                        .WithMany("RealTimeValues")
                        .HasForeignKey("CurrentSensorId");
                });

            modelBuilder.Entity("PowerSystemMonitoring.Data.Models.WeatherStation", b =>
                {
                    b.HasOne("PowerSystemMonitoring.Data.Models.ApplicationUser", "AddedByUser")
                        .WithMany()
                        .HasForeignKey("AddedByUserId");

                    b.HasOne("PowerSystemMonitoring.Data.Models.GeographicalCoordinates", "GeographicalCoordinates")
                        .WithMany()
                        .HasForeignKey("GeographicalCoordinatesId");
                });
#pragma warning restore 612, 618
        }
    }
}
