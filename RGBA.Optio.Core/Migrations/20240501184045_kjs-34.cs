using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RGBA.Optio.Core.Migrations
{
    /// <inheritdoc />
    public partial class kjs34 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CategoryOfTransactions_Transaction_Category",
                table: "CategoryOfTransactions");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryOfTransactions_Transaction_Category",
                table: "CategoryOfTransactions",
                column: "Transaction_Category",
                descending: new bool[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CategoryOfTransactions_Transaction_Category",
                table: "CategoryOfTransactions");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryOfTransactions_Transaction_Category",
                table: "CategoryOfTransactions",
                column: "Transaction_Category",
                unique: true,
                descending: new bool[0]);
        }
    }
}
