using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartDormApi.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedAtToInvoices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Month",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "RoomRent",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "DueDate",
                table: "Invoices",
                newName: "CreatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Invoices",
                newName: "DueDate");

            migrationBuilder.AddColumn<int>(
                name: "Month",
                table: "Invoices",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "RoomRent",
                table: "Invoices",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Invoices",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
