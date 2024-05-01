using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RGBA.Optio.Core.Migrations
{
    /// <inheritdoc />
    public partial class migrate786 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TypeOfTransactions_Transaction_Name",
                table: "TypeOfTransactions");

            migrationBuilder.CreateIndex(
                name: "IX_TypeOfTransactions_Transaction_Name",
                table: "TypeOfTransactions",
                column: "Transaction_Name",
                descending: new bool[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TypeOfTransactions_Transaction_Name",
                table: "TypeOfTransactions");

            migrationBuilder.CreateIndex(
                name: "IX_TypeOfTransactions_Transaction_Name",
                table: "TypeOfTransactions",
                column: "Transaction_Name",
                unique: true,
                descending: new bool[0]);
        }
    }
}
