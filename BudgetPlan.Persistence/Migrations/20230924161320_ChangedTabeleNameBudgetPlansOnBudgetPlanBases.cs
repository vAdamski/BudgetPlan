using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetPlan.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangedTabeleNameBudgetPlansOnBudgetPlanBases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetPlanDetails_BudgetPlans_BudgetPlanBaseId",
                table: "BudgetPlanDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BudgetPlans",
                table: "BudgetPlans");

            migrationBuilder.RenameTable(
                name: "BudgetPlans",
                newName: "BudgetPlanBases");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BudgetPlanBases",
                table: "BudgetPlanBases",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetPlanDetails_BudgetPlanBases_BudgetPlanBaseId",
                table: "BudgetPlanDetails",
                column: "BudgetPlanBaseId",
                principalTable: "BudgetPlanBases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetPlanDetails_BudgetPlanBases_BudgetPlanBaseId",
                table: "BudgetPlanDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BudgetPlanBases",
                table: "BudgetPlanBases");

            migrationBuilder.RenameTable(
                name: "BudgetPlanBases",
                newName: "BudgetPlans");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BudgetPlans",
                table: "BudgetPlans",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetPlanDetails_BudgetPlans_BudgetPlanBaseId",
                table: "BudgetPlanDetails",
                column: "BudgetPlanBaseId",
                principalTable: "BudgetPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
