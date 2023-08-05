using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetPlan.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DeletedTransactionBetweenBudgetPlanDetailsAndTransactionDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionDetails_BudgetPlanDetails_BudgetPlanDetailsId",
                table: "TransactionDetails");

            migrationBuilder.DropIndex(
                name: "IX_TransactionDetails_BudgetPlanDetailsId",
                table: "TransactionDetails");

            migrationBuilder.DropColumn(
                name: "BudgetPlanDetailsId",
                table: "TransactionDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BudgetPlanDetailsId",
                table: "TransactionDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetails_BudgetPlanDetailsId",
                table: "TransactionDetails",
                column: "BudgetPlanDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionDetails_BudgetPlanDetails_BudgetPlanDetailsId",
                table: "TransactionDetails",
                column: "BudgetPlanDetailsId",
                principalTable: "BudgetPlanDetails",
                principalColumn: "Id");
        }
    }
}
