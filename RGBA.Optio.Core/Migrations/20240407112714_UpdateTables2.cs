using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RGBA.Optio.Core.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Curencies_CurencyId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "DateOfValuteCourse",
                table: "ValutesCourses",
                newName: "Last_Updated");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "ValutesCourses",
                newName: "Exchange_Rate");

            migrationBuilder.RenameColumn(
                name: "TransactionName",
                table: "TypeOfTransactions",
                newName: "Transaction_Name");

            migrationBuilder.RenameIndex(
                name: "IX_TypeOfTransactions_TransactionName",
                table: "TypeOfTransactions",
                newName: "IX_TypeOfTransactions_Transaction_Name");

            migrationBuilder.RenameColumn(
                name: "AmountEquivalent",
                table: "Transactions",
                newName: "Amount_Equivalent");

            migrationBuilder.RenameColumn(
                name: "CurencyId",
                table: "Transactions",
                newName: "CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_CurencyId",
                table: "Transactions",
                newName: "IX_Transactions_CurrencyId");

            migrationBuilder.RenameColumn(
                name: "LocationName",
                table: "Locations",
                newName: "Location_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_LocationName",
                table: "Locations",
                newName: "IX_Locations_Location_Name");

            migrationBuilder.RenameColumn(
                name: "NameOfValute",
                table: "Curencies",
                newName: "Name_Of_Valute");

            migrationBuilder.RenameColumn(
                name: "ChannelType",
                table: "Channels",
                newName: "Channel_Type");

            migrationBuilder.RenameIndex(
                name: "IX_Channels_ChannelType",
                table: "Channels",
                newName: "IX_Channels_Channel_Type");

            migrationBuilder.RenameColumn(
                name: "TransactionCategory",
                table: "CategoryOfTransactions",
                newName: "Transaction_Category");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryOfTransactions_TransactionCategory",
                table: "CategoryOfTransactions",
                newName: "IX_CategoryOfTransactions_Transaction_Category");

            migrationBuilder.AlterColumn<string>(
                name: "Transaction_Name",
                table: "TypeOfTransactions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Merchants",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Location_Name",
                table: "Locations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name_Of_Valute",
                table: "Curencies",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Currency_Code",
                table: "Curencies",
                type: "varchar(15)",
                unicode: false,
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Channel_Type",
                table: "Channels",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Transaction_Category",
                table: "CategoryOfTransactions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "User_Surname",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "User_Name",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Curencies_CurrencyId",
                table: "Transactions",
                column: "CurrencyId",
                principalTable: "Curencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Curencies_CurrencyId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Currency_Code",
                table: "Curencies");

            migrationBuilder.RenameColumn(
                name: "Last_Updated",
                table: "ValutesCourses",
                newName: "DateOfValuteCourse");

            migrationBuilder.RenameColumn(
                name: "Exchange_Rate",
                table: "ValutesCourses",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "Transaction_Name",
                table: "TypeOfTransactions",
                newName: "TransactionName");

            migrationBuilder.RenameIndex(
                name: "IX_TypeOfTransactions_Transaction_Name",
                table: "TypeOfTransactions",
                newName: "IX_TypeOfTransactions_TransactionName");

            migrationBuilder.RenameColumn(
                name: "Amount_Equivalent",
                table: "Transactions",
                newName: "AmountEquivalent");

            migrationBuilder.RenameColumn(
                name: "CurrencyId",
                table: "Transactions",
                newName: "CurencyId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_CurrencyId",
                table: "Transactions",
                newName: "IX_Transactions_CurencyId");

            migrationBuilder.RenameColumn(
                name: "Location_Name",
                table: "Locations",
                newName: "LocationName");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_Location_Name",
                table: "Locations",
                newName: "IX_Locations_LocationName");

            migrationBuilder.RenameColumn(
                name: "Name_Of_Valute",
                table: "Curencies",
                newName: "NameOfValute");

            migrationBuilder.RenameColumn(
                name: "Channel_Type",
                table: "Channels",
                newName: "ChannelType");

            migrationBuilder.RenameIndex(
                name: "IX_Channels_Channel_Type",
                table: "Channels",
                newName: "IX_Channels_ChannelType");

            migrationBuilder.RenameColumn(
                name: "Transaction_Category",
                table: "CategoryOfTransactions",
                newName: "TransactionCategory");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryOfTransactions_Transaction_Category",
                table: "CategoryOfTransactions",
                newName: "IX_CategoryOfTransactions_TransactionCategory");

            migrationBuilder.AlterColumn<string>(
                name: "TransactionName",
                table: "TypeOfTransactions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Merchants",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "LocationName",
                table: "Locations",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "NameOfValute",
                table: "Curencies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "ChannelType",
                table: "Channels",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "TransactionCategory",
                table: "CategoryOfTransactions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "User_Surname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "User_Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Curencies_CurencyId",
                table: "Transactions",
                column: "CurencyId",
                principalTable: "Curencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
