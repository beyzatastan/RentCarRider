using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentCar.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCarModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "RentCars",
                newName: "imageUrl");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "RentCars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "DaileyPrice",
                table: "RentCars",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "FuelType",
                table: "RentCars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Mileage",
                table: "RentCars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "RentCars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SeatCount",
                table: "RentCars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "RentCars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Transmission",
                table: "RentCars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "RentCars",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "RentCars");

            migrationBuilder.DropColumn(
                name: "DaileyPrice",
                table: "RentCars");

            migrationBuilder.DropColumn(
                name: "FuelType",
                table: "RentCars");

            migrationBuilder.DropColumn(
                name: "Mileage",
                table: "RentCars");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "RentCars");

            migrationBuilder.DropColumn(
                name: "SeatCount",
                table: "RentCars");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "RentCars");

            migrationBuilder.DropColumn(
                name: "Transmission",
                table: "RentCars");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "RentCars");

            migrationBuilder.RenameColumn(
                name: "imageUrl",
                table: "RentCars",
                newName: "LastName");
        }
    }
}
