using BudgetPlan.Application.Common.Interfaces.Managers;
using BudgetPlan.Shared.ViewModels;
using MediatR;

namespace BudgetPlan.Application.Actions.TransactionCategoriesActions.Queries.GetListTransactionCategoriesForBudgetPlan;

public class GetListTransactionCategoriesForBudgetPlanQueryHandler(
	ITransactionCategoryManager transactionCategoryManager) :
	IRequestHandler<GetListTransactionCategoriesForBudgetPlanQuery, TransactionCategoriesForBudgetPlanViewModel>
{
	public async Task<TransactionCategoriesForBudgetPlanViewModel> Handle(
		GetListTransactionCategoriesForBudgetPlanQuery request, CancellationToken cancellationToken)
	{
		return await transactionCategoryManager
			.GetTransactionCategoriesForBudgetPlan(request.BudgetPlanId, cancellationToken);
	}
}