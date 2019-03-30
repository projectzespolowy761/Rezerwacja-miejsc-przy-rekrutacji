using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationPlaces.Data.Migrations
{
    public partial class AddCorectReservatio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Reservation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pesel",
                table: "Reservation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Reservation",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "Pesel",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Reservation");
        }
    }
}
