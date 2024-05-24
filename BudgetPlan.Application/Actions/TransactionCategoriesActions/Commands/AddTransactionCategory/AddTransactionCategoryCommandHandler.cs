using BudgetPlan.Application.Common.Interfaces.Managers;
using MediatR;

namespace BudgetPlan.Application.Actions.TransactionCategoriesActions.Commands.AddTransactionCategory;

public class AddTransactionCategoryCommandHandler(ITransactionCategoryManager transactionCategoryManager) : IRequestHandler<AddTransactionCategoryCommand, Guid>
{
    public async Task<Guid> Handle(AddTransactionCategoryCommand request, CancellationToken cancellationToken)
    {
        return await transactionCategoryManager.AddTransactionCategoryAsync(request.OverTransactionCategoryId,
            request.Name, cancellationToken);
    }
}