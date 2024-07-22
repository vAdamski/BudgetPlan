using BudgetPlan.Application.Common.Interfaces.Managers;
using MediatR;

namespace BudgetPlan.Application.Actions.TransactionCategoriesActions.Commands.AddOverTransactionCategory;

public class AddOverTransactionCategoryCommandHandler(
	ITransactionCategoryManager transactionCategoryManager)
	: IRequestHandler<AddOverTransactionCategoryCommand, Guid>
{
	public async Task<Guid> Handle(AddOverTransactionCategoryCommand request, CancellationToken cancellationToken)
	{
		return await transactionCategoryManager.AddOverTransactionCategoryAsync(request.BudgetPlanId, request.Name,
			request.TransactionType, cancellationToken);
	}
}