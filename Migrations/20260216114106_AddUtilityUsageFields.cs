using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartDormApi.Migrations
{
    /// <inheritdoc />
    public partial class AddUtilityUsageFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ElectricityCurrent",
                table: "UtilityUsages");

            migrationBuilder.DropColumn(
                name: "ElectricityPrevious",
                table: "UtilityUsages");

            migrationBuilder.DropColumn(
                name: "ElectricityRate",
                table: "UtilityUsages");

            migrationBuilder.DropColumn(
                name: "WaterCurrent",
                table: "UtilityUsages");

            migrationBuilder.DropColumn(
                name: "WaterPrevious",
                table: "UtilityUsages");

            migrationBuilder.DropColumn(
                name: "WaterRate",
                table: "UtilityUsages");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "UtilityUsages",
                newName: "PreviousWaterMeter");

            migrationBuilder.RenameColumn(
                name: "RecordedDate",
                table: "UtilityUsages",
                newName: "ReadingDate");

            migrationBuilder.RenameColumn(
                name: "Month",
                table: "UtilityUsages",
                newName: "PreviousElectricityMeter");

            migrationBuilder.AddColumn<int>(
                name: "CurrentElectricityMeter",
                table: "UtilityUsages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentWaterMeter",
                table: "UtilityUsages",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentElectricityMeter",
                table: "UtilityUsages");

            migrationBuilder.DropColumn(
                name: "CurrentWaterMeter",
                table: "UtilityUsages");

            migrationBuilder.RenameColumn(
                name: "ReadingDate",
                table: "UtilityUsages",
                newName: "RecordedDate");

            migrationBuilder.RenameColumn(
                name: "PreviousWaterMeter",
                table: "UtilityUsages",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "PreviousElectricityMeter",
                table: "UtilityUsages",
                newName: "Month");

            migrationBuilder.AddColumn<double>(
                name: "ElectricityCurrent",
                table: "UtilityUsages",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ElectricityPrevious",
                table: "UtilityUsages",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ElectricityRate",
                table: "UtilityUsages",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "WaterCurrent",
                table: "UtilityUsages",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "WaterPrevious",
                table: "UtilityUsages",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "WaterRate",
                table: "UtilityUsages",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
