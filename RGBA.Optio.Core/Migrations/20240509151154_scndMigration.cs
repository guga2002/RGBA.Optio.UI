using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RGBA.Optio.Core.Migrations
{
    /// <inheritdoc />
    public partial class scndMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TypeOfTransactions_Transaction_Name",
                table: "TypeOfTransactions");

            migrationBuilder.DropIndex(
                name: "IX_Merchants_Name",
                table: "Merchants");

            migrationBuilder.DropIndex(
                name: "IX_Locations_Location_Name",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Curencies_Currency_Code",
                table: "Curencies");

            migrationBuilder.DropIndex(
                name: "IX_Channels_Channel_Type",
                table: "Channels");

            migrationBuilder.DropIndex(
                name: "IX_CategoryOfTransactions_Transaction_Category",
                table: "CategoryOfTransactions");

            migrationBuilder.CreateIndex(
                name: "IX_TypeOfTransactions_Transaction_Name",
                table: "TypeOfTransactions",
                column: "Transaction_Name",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_Merchants_Name",
                table: "Merchants",
                column: "Name",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Location_Name",
                table: "Locations",
                column: "Location_Name",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_Curencies_Currency_Code",
                table: "Curencies",
                column: "Currency_Code",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_Channels_Channel_Type",
                table: "Channels",
                column: "Channel_Type",
                descending: new bool[0]);

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
                name: "IX_TypeOfTransactions_Transaction_Name",
                table: "TypeOfTransactions");

            migrationBuilder.DropIndex(
                name: "IX_Merchants_Name",
                table: "Merchants");

            migrationBuilder.DropIndex(
                name: "IX_Locations_Location_Name",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Curencies_Currency_Code",
                table: "Curencies");

            migrationBuilder.DropIndex(
                name: "IX_Channels_Channel_Type",
                table: "Channels");

            migrationBuilder.DropIndex(
                name: "IX_CategoryOfTransactions_Transaction_Category",
                table: "CategoryOfTransactions");

            migrationBuilder.CreateIndex(
                name: "IX_TypeOfTransactions_Transaction_Name",
                table: "TypeOfTransactions",
                column: "Transaction_Name",
                unique: true,
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_Merchants_Name",
                table: "Merchants",
                column: "Name",
                unique: true,
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Location_Name",
                table: "Locations",
                column: "Location_Name",
                unique: true,
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_Curencies_Currency_Code",
                table: "Curencies",
                column: "Currency_Code",
                unique: true,
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_Channels_Channel_Type",
                table: "Channels",
                column: "Channel_Type",
                unique: true,
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryOfTransactions_Transaction_Category",
                table: "CategoryOfTransactions",
                column: "Transaction_Category",
                unique: true,
                descending: new bool[0]);
        }
    }
}
