using MediatR;

namespace BudgetPlan.Application.TransactionCategories.Commands.AddTransactionCategory;

public class AddTransactionCategoryCommandHandler : IRequestHandler<AddTransactionCategoryCommand, int>
{
    public async Task<int> Handle(AddTransactionCategoryCommand request, CancellationToken cancellationToken)
    {
        return 0;
    }
}