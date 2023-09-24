using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetPlan.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangedDataTypeFloatOnDouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "BudgetPlanDetails");

            migrationBuilder.AlterColumn<double>(
                name: "Value",
                table: "TransactionDetails",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<double>(
                name: "ExpectedAmount",
                table: "BudgetPlanDetails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpectedAmount",
                table: "BudgetPlanDetails");

            migrationBuilder.AlterColumn<float>(
                name: "Value",
                table: "TransactionDetails",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<float>(
                name: "Value",
                table: "BudgetPlanDetails",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
