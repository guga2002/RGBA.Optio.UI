using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RGBA.Optio.Core.Migrations
{
    /// <inheritdoc />
    public partial class Indexes_Update : Migration
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
                name: "IX_Channels_Channel_Type",
                table: "Channels");

            migrationBuilder.DropIndex(
                name: "IX_CategoryOfTransactions_Transaction_Category",
                table: "CategoryOfTransactions");

            migrationBuilder.AlterColumn<decimal>(
                name: "Exchange_Rate",
                table: "ValutesCourses",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<string>(
                name: "Currency_Code",
                table: "Curencies",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldUnicode: false,
                oldMaxLength: 15);

            migrationBuilder.AddColumn<string>(
                name: "Personal_Number",
                table: "AspNetUsers",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ValutesCourses_Exchange_Rate",
                table: "ValutesCourses",
                column: "Exchange_Rate",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_ValutesCourses_Last_Updated",
                table: "ValutesCourses",
                column: "Last_Updated",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_TypeOfTransactions_Transaction_Name",
                table: "TypeOfTransactions",
                column: "Transaction_Name",
                unique: true,
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_Amount",
                table: "Transactions",
                column: "Amount",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_Amount_Equivalent",
                table: "Transactions",
                column: "Amount_Equivalent",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_Date_Of_Transaction",
                table: "Transactions",
                column: "Date_Of_Transaction",
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
                name: "IX_Curencies_Name_Of_Valute",
                table: "Curencies",
                column: "Name_Of_Valute",
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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Personal_Number",
                table: "AspNetUsers",
                column: "Personal_Number",
                unique: true,
                descending: new bool[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ValutesCourses_Exchange_Rate",
                table: "ValutesCourses");

            migrationBuilder.DropIndex(
                name: "IX_ValutesCourses_Last_Updated",
                table: "ValutesCourses");

            migrationBuilder.DropIndex(
                name: "IX_TypeOfTransactions_Transaction_Name",
                table: "TypeOfTransactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_Amount",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_Amount_Equivalent",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_Date_Of_Transaction",
                table: "Transactions");

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
                name: "IX_Curencies_Name_Of_Valute",
                table: "Curencies");

            migrationBuilder.DropIndex(
                name: "IX_Channels_Channel_Type",
                table: "Channels");

            migrationBuilder.DropIndex(
                name: "IX_CategoryOfTransactions_Transaction_Category",
                table: "CategoryOfTransactions");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Personal_Number",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Personal_Number",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<float>(
                name: "Exchange_Rate",
                table: "ValutesCourses",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<float>(
                name: "Amount",
                table: "Transactions",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Currency_Code",
                table: "Curencies",
                type: "varchar(15)",
                unicode: false,
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.CreateIndex(
                name: "IX_TypeOfTransactions_Transaction_Name",
                table: "TypeOfTransactions",
                column: "Transaction_Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Merchants_Name",
                table: "Merchants",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Location_Name",
                table: "Locations",
                column: "Location_Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Channels_Channel_Type",
                table: "Channels",
                column: "Channel_Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryOfTransactions_Transaction_Category",
                table: "CategoryOfTransactions",
                column: "Transaction_Category",
                unique: true);
        }
    }
}
