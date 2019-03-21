using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationPlaces.Data.Migrations
{
    public partial class AddAdminSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminSettings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(maxLength: 450, nullable: true),
                    StartPeriod = table.Column<DateTime>(nullable: false),
                    EndPeriod = table.Column<DateTime>(nullable: false),
                    Interval = table.Column<int>(nullable: false),
                    OpenHour = table.Column<DateTime>(nullable: false),
                    CloseHour = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminSettings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminSettings");
        }
    }
}
