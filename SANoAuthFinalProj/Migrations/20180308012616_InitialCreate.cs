using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SANoAuthFinalProj.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sensor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DataPoint",
                columns: table => new
                {
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    BMI = table.Column<double>(nullable: false),
                    CaloriesBurned = table.Column<int>(nullable: false),
                    CaloriesIn = table.Column<int>(nullable: false),
                    CarbsConsumed = table.Column<int>(nullable: false),
                    FatConsumed = table.Column<int>(nullable: false),
                    FiberConsumed = table.Column<int>(nullable: false),
                    ID = table.Column<int>(nullable: false),
                    MinutesAsleep = table.Column<int>(nullable: false),
                    MinutesAwake = table.Column<int>(nullable: false),
                    ProteinConsumed = table.Column<int>(nullable: false),
                    SodiumConsumed = table.Column<int>(nullable: false),
                    Steps = table.Column<int>(nullable: false),
                    WaterConsumed = table.Column<int>(nullable: false),
                    Weight = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataPoint", x => x.TimeStamp);
                    table.ForeignKey(
                        name: "FK_DataPoint_Sensor_ID",
                        column: x => x.ID,
                        principalTable: "Sensor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataPoint_ID",
                table: "DataPoint",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataPoint");

            migrationBuilder.DropTable(
                name: "Sensor");
        }
    }
}
