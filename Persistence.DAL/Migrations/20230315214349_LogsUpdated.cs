using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.DAL.Migrations
{
    /// <inheritdoc />
    public partial class LogsUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Logs",
                newName: "StackTrace");

            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Headers",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Route",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Body",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "Headers",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "Route",
                table: "Logs");

            migrationBuilder.RenameColumn(
                name: "StackTrace",
                table: "Logs",
                newName: "EventId");
        }
    }
}
