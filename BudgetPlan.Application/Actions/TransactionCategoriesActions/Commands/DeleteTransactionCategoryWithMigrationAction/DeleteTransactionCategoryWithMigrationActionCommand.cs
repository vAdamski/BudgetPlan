using MediatR;

namespace BudgetPlan.Application.Actions.TransactionCategoriesActions.Commands.DeleteTransactionCategoryWithMigrationAction;

public class DeleteTransactionCategoryWithMigrationActionCommand : IRequest
{
    public DeleteTransactionCategoryWithMigrationActionCommand(Guid id, Guid migrationId)
    {
        Id = id;
        MigrationId = migrationId;
    }

    public Guid Id { get; set; }
    public Guid MigrationId { get; set; }
}