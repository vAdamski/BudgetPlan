using MediatR;

namespace BudgetPlan.Application.Actions.TransactionCategoriesActions.Commands.DeleteTransactionCategory;

public class DeleteTransactionCategoryCommand : IRequest
{
    public DeleteTransactionCategoryCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}