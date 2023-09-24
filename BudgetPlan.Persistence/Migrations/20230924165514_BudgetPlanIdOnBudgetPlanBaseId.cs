using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetPlan.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BudgetPlanIdOnBudgetPlanBaseId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetPlanDetails_BudgetPlanBases_BudgetPlanBaseId",
                table: "BudgetPlanDetails");

            migrationBuilder.DropColumn(
                name: "BudgetPlanId",
                table: "BudgetPlanDetails");

            migrationBuilder.AlterColumn<int>(
                name: "BudgetPlanBaseId",
                table: "BudgetPlanDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetPlanDetails_BudgetPlanBases_BudgetPlanBaseId",
                table: "BudgetPlanDetails",
                column: "BudgetPlanBaseId",
                principalTable: "BudgetPlanBases",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetPlanDetails_BudgetPlanBases_BudgetPlanBaseId",
                table: "BudgetPlanDetails");

            migrationBuilder.AlterColumn<int>(
                name: "BudgetPlanBaseId",
                table: "BudgetPlanDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BudgetPlanId",
                table: "BudgetPlanDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetPlanDetails_BudgetPlanBases_BudgetPlanBaseId",
                table: "BudgetPlanDetails",
                column: "BudgetPlanBaseId",
                principalTable: "BudgetPlanBases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
