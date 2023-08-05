using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetPlan.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewTableAndConfigurationUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "BudgetPlanDetails");

            migrationBuilder.DropColumn(
                name: "DateTo",
                table: "BudgetPlanDetails");

            migrationBuilder.AddColumn<int>(
                name: "BudgetPlanId",
                table: "BudgetPlanDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BudgetPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    InactivatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Inactivated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetPlans", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetails_TransactionCategoryId",
                table: "TransactionDetails",
                column: "TransactionCategoryId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionDetails_TransactionCategories_TransactionCategoryId",
                table: "TransactionDetails",
                column: "TransactionCategoryId",
                principalTable: "TransactionCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetPlanDetails_BudgetPlans_BudgetPlanId",
                table: "BudgetPlanDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionDetails_TransactionCategories_TransactionCategoryId",
                table: "TransactionDetails");

            migrationBuilder.DropTable(
                name: "BudgetPlans");

            migrationBuilder.DropIndex(
                name: "IX_TransactionDetails_TransactionCategoryId",
                table: "TransactionDetails");

            migrationBuilder.DropIndex(
                name: "IX_BudgetPlanDetails_BudgetPlanId",
                table: "BudgetPlanDetails");

            migrationBuilder.DropColumn(
                name: "BudgetPlanId",
                table: "BudgetPlanDetails");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFrom",
                table: "BudgetPlanDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTo",
                table: "BudgetPlanDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
