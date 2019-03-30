using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationPlaces.Data.Migrations
{
    public partial class EmailSender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Reservation",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Reservation");
        }
    }
}
