using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetPlan.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedBudgetPlanTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BudgetPlanId",
                table: "BudgetPlanBases",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "BudgetPlan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_BudgetPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BudgetPlan_Accesses_AccessId",
                        column: x => x.AccessId,
                        principalTable: "Accesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BudgetPlanBases_BudgetPlanId",
                table: "BudgetPlanBases",
                column: "BudgetPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetPlan_AccessId",
                table: "BudgetPlan",
                column: "AccessId");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetPlanBases_BudgetPlan_BudgetPlanId",
                table: "BudgetPlanBases",
                column: "BudgetPlanId",
                principalTable: "BudgetPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetPlanBases_BudgetPlan_BudgetPlanId",
                table: "BudgetPlanBases");

            migrationBuilder.DropTable(
                name: "BudgetPlan");

            migrationBuilder.DropIndex(
                name: "IX_BudgetPlanBases_BudgetPlanId",
                table: "BudgetPlanBases");

            migrationBuilder.DropColumn(
                name: "BudgetPlanId",
                table: "BudgetPlanBases");
        }
    }
}
