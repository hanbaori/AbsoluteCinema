using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbsoluteCinema.Migrations
{
    /// <inheritdoc />
    public partial class updatebookingandusermodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Bookings_BookingId",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Shows_BookingId",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Shows");

            migrationBuilder.AddColumn<int>(
                name: "BookedSeats",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookedSeats",
                table: "Bookings");

            migrationBuilder.AddColumn<Guid>(
                name: "BookingId",
                table: "Shows",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: new Guid("7038a7d2-652c-45fb-9160-135b0cd580bf"),
                column: "BookingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: new Guid("82d002bc-67f8-448f-aeb1-15db7d474f8e"),
                column: "BookingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: new Guid("94d9c9ac-6c5e-4e51-86cc-990405d84583"),
                column: "BookingId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Shows_BookingId",
                table: "Shows",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Bookings_BookingId",
                table: "Shows",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id");
        }
    }
}
