using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationPlaces.Data.Migrations
{
    public partial class ChangeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReservationDate",
                table: "Reservation",
                newName: "StartVisit");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndVisit",
                table: "Reservation",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndVisit",
                table: "Reservation");

            migrationBuilder.RenameColumn(
                name: "StartVisit",
                table: "Reservation",
                newName: "ReservationDate");
        }
    }
}
