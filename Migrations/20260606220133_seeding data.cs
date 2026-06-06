using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AbsoluteCinema.Migrations
{
    /// <inheritdoc />
    public partial class seedingdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ShowImageUrl",
                table: "Shows",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Shows",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Shows",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Genres",
                table: "Shows",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "Id", "BookingId", "Description", "Genres", "Name", "ShowDate", "ShowImageUrl" },
                values: new object[,]
                {
                    { new Guid("7038a7d2-652c-45fb-9160-135b0cd580bf"), null, "A battle-hardened Kara Zor-El journeys across a harsh universe, forging her own identity as Supergirl while turning pain, loss, and fury into a new kind of hope.", "[10,8,11]", "Supergirl", new DateTime(2026, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("82d002bc-67f8-448f-aeb1-15db7d474f8e"), null, "Odysseus, king of Ithaca, embarks on a perilous journey to return home after the Trojan War.", "[0,8,11]", "The Odyssey", new DateTime(2026, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("94d9c9ac-6c5e-4e51-86cc-990405d84583"), null, "\"No more terrible disaster could befall your people than for them to fall into the hands of a hero\"", "[9,10,0]", "Dune 3", new DateTime(2026, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Role" },
                values: new object[,]
                {
                    { new Guid("850b3567-e7e4-4bd1-a1a6-ed802f68cd46"), "Admin", 2 },
                    { new Guid("e5d5c3ea-a7ed-4dbc-8091-86a548c78a12"), "User", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: new Guid("7038a7d2-652c-45fb-9160-135b0cd580bf"));

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: new Guid("82d002bc-67f8-448f-aeb1-15db7d474f8e"));

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: new Guid("94d9c9ac-6c5e-4e51-86cc-990405d84583"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("850b3567-e7e4-4bd1-a1a6-ed802f68cd46"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e5d5c3ea-a7ed-4dbc-8091-86a548c78a12"));

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Genres",
                table: "Shows");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ShowImageUrl",
                table: "Shows",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Shows",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Shows",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);
        }
    }
}
