using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetPlan.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addTransactionDetailDto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "TransactionDate",
                table: "TransactionDetails",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDate",
                table: "TransactionDetails",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }
    }
}
