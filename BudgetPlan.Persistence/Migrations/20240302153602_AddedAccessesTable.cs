using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetPlan.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedAccessesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AccessId",
                table: "TransactionDetails",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AccessId",
                table: "TransactionCategories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AccessId",
                table: "BudgetPlanDetails",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AccessId",
                table: "BudgetPlanBases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Accesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Accesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccessedPersons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccessId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_AccessedPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessedPersons_Accesses_AccessId",
                        column: x => x.AccessId,
                        principalTable: "Accesses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetails_AccessId",
                table: "TransactionDetails",
                column: "AccessId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionCategories_AccessId",
                table: "TransactionCategories",
                column: "AccessId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetPlanDetails_AccessId",
                table: "BudgetPlanDetails",
                column: "AccessId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetPlanBases_AccessId",
                table: "BudgetPlanBases",
                column: "AccessId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessedPersons_AccessId",
                table: "AccessedPersons",
                column: "AccessId");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetPlanBases_Accesses_AccessId",
                table: "BudgetPlanBases",
                column: "AccessId",
                principalTable: "Accesses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetPlanDetails_Accesses_AccessId",
                table: "BudgetPlanDetails",
                column: "AccessId",
                principalTable: "Accesses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionCategories_Accesses_AccessId",
                table: "TransactionCategories",
                column: "AccessId",
                principalTable: "Accesses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionDetails_Accesses_AccessId",
                table: "TransactionDetails",
                column: "AccessId",
                principalTable: "Accesses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetPlanBases_Accesses_AccessId",
                table: "BudgetPlanBases");

            migrationBuilder.DropForeignKey(
                name: "FK_BudgetPlanDetails_Accesses_AccessId",
                table: "BudgetPlanDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionCategories_Accesses_AccessId",
                table: "TransactionCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionDetails_Accesses_AccessId",
                table: "TransactionDetails");

            migrationBuilder.DropTable(
                name: "AccessedPersons");

            migrationBuilder.DropTable(
                name: "Accesses");

            migrationBuilder.DropIndex(
                name: "IX_TransactionDetails_AccessId",
                table: "TransactionDetails");

            migrationBuilder.DropIndex(
                name: "IX_TransactionCategories_AccessId",
                table: "TransactionCategories");

            migrationBuilder.DropIndex(
                name: "IX_BudgetPlanDetails_AccessId",
                table: "BudgetPlanDetails");

            migrationBuilder.DropIndex(
                name: "IX_BudgetPlanBases_AccessId",
                table: "BudgetPlanBases");

            migrationBuilder.DropColumn(
                name: "AccessId",
                table: "TransactionDetails");

            migrationBuilder.DropColumn(
                name: "AccessId",
                table: "TransactionCategories");

            migrationBuilder.DropColumn(
                name: "AccessId",
                table: "BudgetPlanDetails");

            migrationBuilder.DropColumn(
                name: "AccessId",
                table: "BudgetPlanBases");
        }
    }
}
