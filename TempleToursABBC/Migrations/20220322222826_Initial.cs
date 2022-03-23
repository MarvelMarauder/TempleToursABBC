using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TempleToursABBC.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimeSlots",
                columns: table => new
                {
                    TimeSlotId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Slot = table.Column<DateTime>(nullable: false),
                    Available = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlots", x => x.TimeSlotId);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GroupName = table.Column<string>(nullable: false),
                    GroupSize = table.Column<int>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    TimeSlotId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointments_TimeSlots_TimeSlotId",
                        column: x => x.TimeSlotId,
                        principalTable: "TimeSlots",
                        principalColumn: "TimeSlotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "TimeSlotId", "Available", "Slot" },
                values: new object[] { 1, true, new DateTime(2022, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "TimeSlotId", "Available", "Slot" },
                values: new object[] { 2, true, new DateTime(2022, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "TimeSlotId", "Available", "Slot" },
                values: new object[] { 3, true, new DateTime(2022, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "TimeSlotId", "Available", "Slot" },
                values: new object[] { 4, true, new DateTime(2022, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_TimeSlotId",
                table: "Appointments",
                column: "TimeSlotId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "TimeSlots");
        }
    }
}
