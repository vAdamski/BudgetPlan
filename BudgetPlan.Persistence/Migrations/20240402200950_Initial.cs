using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetPlan.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataAccesses",
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
                    table.PrimaryKey("PK_DataAccesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccessedPersons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataAccessId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                        name: "FK_AccessedPersons_DataAccesses_DataAccessId",
                        column: x => x.DataAccessId,
                        principalTable: "DataAccesses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BudgetPlanEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataAccessId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                        name: "FK_BudgetPlanEntities_DataAccesses_DataAccessId",
                        column: x => x.DataAccessId,
                        principalTable: "DataAccesses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BudgetPlanBases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateFrom = table.Column<DateOnly>(type: "date", nullable: false),
                    DateTo = table.Column<DateOnly>(type: "date", nullable: false),
                    BudgetPlanEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataAccessId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_BudgetPlanBases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BudgetPlanBases_BudgetPlanEntities_BudgetPlanEntityId",
                        column: x => x.BudgetPlanEntityId,
                        principalTable: "BudgetPlanEntities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BudgetPlanBases_DataAccesses_DataAccessId",
                        column: x => x.DataAccessId,
                        principalTable: "DataAccesses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TransactionCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    OverTransactionCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BudgetPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_TransactionCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionCategories_BudgetPlanEntities_BudgetPlanId",
                        column: x => x.BudgetPlanId,
                        principalTable: "BudgetPlanEntities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransactionCategories_DataAccesses_AccessId",
                        column: x => x.AccessId,
                        principalTable: "DataAccesses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransactionCategories_TransactionCategories_OverTransactionCategoryId",
                        column: x => x.OverTransactionCategoryId,
                        principalTable: "TransactionCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BudgetPlanDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpectedAmount = table.Column<double>(type: "float", nullable: false),
                    BudgetPlanType = table.Column<int>(type: "int", nullable: false),
                    BudgetPlanBaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TransactionCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataAccessId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_BudgetPlanDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BudgetPlanDetails_BudgetPlanBases_BudgetPlanBaseId",
                        column: x => x.BudgetPlanBaseId,
                        principalTable: "BudgetPlanBases",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BudgetPlanDetails_DataAccesses_DataAccessId",
                        column: x => x.DataAccessId,
                        principalTable: "DataAccesses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BudgetPlanDetails_TransactionCategories_TransactionCategoryId",
                        column: x => x.TransactionCategoryId,
                        principalTable: "TransactionCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TransactionDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_TransactionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionDetails_DataAccesses_AccessId",
                        column: x => x.AccessId,
                        principalTable: "DataAccesses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransactionDetails_TransactionCategories_TransactionCategoryId",
                        column: x => x.TransactionCategoryId,
                        principalTable: "TransactionCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessedPersons_DataAccessId",
                table: "AccessedPersons",
                column: "DataAccessId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetPlanBases_BudgetPlanEntityId",
                table: "BudgetPlanBases",
                column: "BudgetPlanEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetPlanBases_DataAccessId",
                table: "BudgetPlanBases",
                column: "DataAccessId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetPlanDetails_BudgetPlanBaseId",
                table: "BudgetPlanDetails",
                column: "BudgetPlanBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetPlanDetails_DataAccessId",
                table: "BudgetPlanDetails",
                column: "DataAccessId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetPlanDetails_TransactionCategoryId",
                table: "BudgetPlanDetails",
                column: "TransactionCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetPlanEntities_DataAccessId",
                table: "BudgetPlanEntities",
                column: "DataAccessId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionCategories_AccessId",
                table: "TransactionCategories",
                column: "AccessId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionCategories_BudgetPlanId",
                table: "TransactionCategories",
                column: "BudgetPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionCategories_OverTransactionCategoryId",
                table: "TransactionCategories",
                column: "OverTransactionCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetails_AccessId",
                table: "TransactionDetails",
                column: "AccessId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetails_TransactionCategoryId",
                table: "TransactionDetails",
                column: "TransactionCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessedPersons");

            migrationBuilder.DropTable(
                name: "BudgetPlanDetails");

            migrationBuilder.DropTable(
                name: "TransactionDetails");

            migrationBuilder.DropTable(
                name: "BudgetPlanBases");

            migrationBuilder.DropTable(
                name: "TransactionCategories");

            migrationBuilder.DropTable(
                name: "BudgetPlanEntities");

            migrationBuilder.DropTable(
                name: "DataAccesses");
        }
    }
}
