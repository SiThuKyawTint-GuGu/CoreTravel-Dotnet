using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreTravel.Migrations
{
    /// <inheritdoc />
    public partial class CustomerHasBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerHasBookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Customer_Id = table.Column<int>(type: "int", nullable: true),
                    Booking_Id = table.Column<int>(type: "int", nullable: true),
                    Paymentinfo_Id = table.Column<int>(type: "int", nullable: true),
                    Date_of_booking = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Total_amount = table.Column<int>(type: "int", nullable: true),
                    BookingStatus_Id = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerHasBookings", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerHasBookings");
        }
    }
}
