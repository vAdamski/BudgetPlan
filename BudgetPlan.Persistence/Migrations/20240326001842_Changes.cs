using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetPlan.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetPlanBases_BudgetPlan_BudgetPlanId",
                table: "BudgetPlanBases");

            migrationBuilder.DropTable(
                name: "BudgetPlan");

            migrationBuilder.RenameColumn(
                name: "BudgetPlanId",
                table: "BudgetPlanBases",
                newName: "BudgetPlanEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_BudgetPlanBases_BudgetPlanId",
                table: "BudgetPlanBases",
                newName: "IX_BudgetPlanBases_BudgetPlanEntityId");

            migrationBuilder.CreateTable(
                name: "BudgetPlanEntities",
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
                    table.PrimaryKey("PK_BudgetPlanEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BudgetPlanEntities_Accesses_AccessId",
                        column: x => x.AccessId,
                        principalTable: "Accesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BudgetPlanEntities_AccessId",
                table: "BudgetPlanEntities",
                column: "AccessId");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetPlanBases_BudgetPlanEntities_BudgetPlanEntityId",
                table: "BudgetPlanBases",
                column: "BudgetPlanEntityId",
                principalTable: "BudgetPlanEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetPlanBases_BudgetPlanEntities_BudgetPlanEntityId",
                table: "BudgetPlanBases");

            migrationBuilder.DropTable(
                name: "BudgetPlanEntities");

            migrationBuilder.RenameColumn(
                name: "BudgetPlanEntityId",
                table: "BudgetPlanBases",
                newName: "BudgetPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_BudgetPlanBases_BudgetPlanEntityId",
                table: "BudgetPlanBases",
                newName: "IX_BudgetPlanBases_BudgetPlanId");

            migrationBuilder.CreateTable(
                name: "BudgetPlan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Inactivated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InactivatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
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
    }
}
