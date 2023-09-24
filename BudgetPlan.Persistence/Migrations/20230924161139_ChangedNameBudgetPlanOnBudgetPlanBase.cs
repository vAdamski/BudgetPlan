using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetPlan.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangedNameBudgetPlanOnBudgetPlanBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetPlanDetails_BudgetPlans_BudgetPlanId",
                table: "BudgetPlanDetails");

            migrationBuilder.DropIndex(
                name: "IX_BudgetPlanDetails_BudgetPlanId",
                table: "BudgetPlanDetails");

            migrationBuilder.AddColumn<int>(
                name: "BudgetPlanBaseId",
                table: "BudgetPlanDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BudgetPlanDetails_BudgetPlanBaseId",
                table: "BudgetPlanDetails",
                column: "BudgetPlanBaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetPlanDetails_BudgetPlans_BudgetPlanBaseId",
                table: "BudgetPlanDetails",
                column: "BudgetPlanBaseId",
                principalTable: "BudgetPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetPlanDetails_BudgetPlans_BudgetPlanBaseId",
                table: "BudgetPlanDetails");

            migrationBuilder.DropIndex(
                name: "IX_BudgetPlanDetails_BudgetPlanBaseId",
                table: "BudgetPlanDetails");

            migrationBuilder.DropColumn(
                name: "BudgetPlanBaseId",
                table: "BudgetPlanDetails");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetPlanDetails_BudgetPlanId",
                table: "BudgetPlanDetails",
                column: "BudgetPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetPlanDetails_BudgetPlans_BudgetPlanId",
                table: "BudgetPlanDetails",
                column: "BudgetPlanId",
                principalTable: "BudgetPlans",
                principalColumn: "Id");
        }
    }
}
