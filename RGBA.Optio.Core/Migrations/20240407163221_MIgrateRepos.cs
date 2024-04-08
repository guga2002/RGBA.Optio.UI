using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RGBA.Optio.Core.Migrations
{
    /// <inheritdoc />
    public partial class MIgrateRepos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status_Of_Valute",
                table: "ValutesCourses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status_Of_Transaction_Type",
                table: "TypeOfTransactions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Transaction_Status",
                table: "Transactions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status_Of_Currency",
                table: "Curencies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status_Of_Valute",
                table: "ValutesCourses");

            migrationBuilder.DropColumn(
                name: "Status_Of_Transaction_Type",
                table: "TypeOfTransactions");

            migrationBuilder.DropColumn(
                name: "Transaction_Status",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Status_Of_Currency",
                table: "Curencies");
        }
    }
}
