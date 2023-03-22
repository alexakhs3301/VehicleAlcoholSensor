using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VehicleAlcoholSensor.EF.Migrations
{
    public partial class migr_0000_2023 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Metrics_VehicleDrivers_VehicleDriverId",
                schema: "public",
                table: "Metrics");

            migrationBuilder.DropTable(
                name: "VehicleDrivers",
                schema: "public");

            migrationBuilder.DropColumn(
                name: "Percentage",
                schema: "public",
                table: "Metrics");

            migrationBuilder.RenameColumn(
                name: "VehicleDriverId",
                schema: "public",
                table: "Metrics",
                newName: "VehicleDriverDeviceId");

            migrationBuilder.RenameIndex(
                name: "IX_Metrics_VehicleDriverId",
                schema: "public",
                table: "Metrics",
                newName: "IX_Metrics_VehicleDriverDeviceId");

            migrationBuilder.AddColumn<int>(
                name: "Concentration",
                schema: "public",
                table: "Metrics",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Timestamp",
                schema: "public",
                table: "Metrics",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Device",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    SerialNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleDriverDevices",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DriverId = table.Column<int>(type: "integer", nullable: true),
                    VehicleId = table.Column<int>(type: "integer", nullable: true),
                    DeviceId = table.Column<int>(type: "integer", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDriverDevices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleDriverDevices_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "public",
                        principalTable: "Device",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehicleDriverDevices_Users_DriverId",
                        column: x => x.DriverId,
                        principalSchema: "public",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehicleDriverDevices_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalSchema: "public",
                        principalTable: "Vehicles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_LicensePlate",
                schema: "public",
                table: "Vehicles",
                column: "LicensePlate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_EMail",
                schema: "public",
                table: "Users",
                column: "EMail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                schema: "public",
                table: "Users",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Device_SerialNumber",
                schema: "public",
                table: "Device",
                column: "SerialNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDriverDevices_DeviceId",
                schema: "public",
                table: "VehicleDriverDevices",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDriverDevices_DriverId",
                schema: "public",
                table: "VehicleDriverDevices",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDriverDevices_VehicleId",
                schema: "public",
                table: "VehicleDriverDevices",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Metrics_VehicleDriverDevices_VehicleDriverDeviceId",
                schema: "public",
                table: "Metrics",
                column: "VehicleDriverDeviceId",
                principalSchema: "public",
                principalTable: "VehicleDriverDevices",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Metrics_VehicleDriverDevices_VehicleDriverDeviceId",
                schema: "public",
                table: "Metrics");

            migrationBuilder.DropTable(
                name: "VehicleDriverDevices",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Device",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_LicensePlate",
                schema: "public",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Users_EMail",
                schema: "public",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Username",
                schema: "public",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Concentration",
                schema: "public",
                table: "Metrics");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                schema: "public",
                table: "Metrics");

            migrationBuilder.RenameColumn(
                name: "VehicleDriverDeviceId",
                schema: "public",
                table: "Metrics",
                newName: "VehicleDriverId");

            migrationBuilder.RenameIndex(
                name: "IX_Metrics_VehicleDriverDeviceId",
                schema: "public",
                table: "Metrics",
                newName: "IX_Metrics_VehicleDriverId");

            migrationBuilder.AddColumn<float>(
                name: "Percentage",
                schema: "public",
                table: "Metrics",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "VehicleDrivers",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DriverId = table.Column<int>(type: "integer", nullable: true),
                    VehicleId = table.Column<int>(type: "integer", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDrivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleDrivers_Users_DriverId",
                        column: x => x.DriverId,
                        principalSchema: "public",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehicleDrivers_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalSchema: "public",
                        principalTable: "Vehicles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDrivers_DriverId",
                schema: "public",
                table: "VehicleDrivers",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDrivers_VehicleId",
                schema: "public",
                table: "VehicleDrivers",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Metrics_VehicleDrivers_VehicleDriverId",
                schema: "public",
                table: "Metrics",
                column: "VehicleDriverId",
                principalSchema: "public",
                principalTable: "VehicleDrivers",
                principalColumn: "Id");
        }
    }
}
