using MediatR;

namespace BudgetPlan.Application.Actions.TransactionCategoriesActions.Commands.AddTransactionCategory;

public class AddTransactionCategoryCommand : IRequest<Guid>
{
    public Guid OverTransactionCategoryId { get; }
    public string Name { get; }

    public AddTransactionCategoryCommand(Guid overTransactionCategoryId, string name)
    {
        OverTransactionCategoryId = overTransactionCategoryId;
        Name = name;
    }
}