using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakeMyTrip.Data.Migrations
{
    /// <inheritdoc />
    public partial class database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirlineService",
                columns: table => new
                {
                    AirlineSeriveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Avaialable = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirlineService", x => x.AirlineSeriveId);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    FlightDeatil = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirlineServiceId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirlineServicesAirlineSeriveId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.FlightDeatil);
                    table.ForeignKey(
                        name: "FK_Flight_AirlineService_AirlineServicesAirlineSeriveId",
                        column: x => x.AirlineServicesAirlineSeriveId,
                        principalTable: "AirlineService",
                        principalColumn: "AirlineSeriveId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flight_AirlineServicesAirlineSeriveId",
                table: "Flight",
                column: "AirlineServicesAirlineSeriveId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "AirlineService");
        }
    }
}
