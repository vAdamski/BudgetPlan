using BudgetPlan.Application.Common.Interfaces.Managers;
using BudgetPlan.Shared.ViewModels;
using MediatR;

namespace BudgetPlan.Application.Actions.TransactionCategoriesActions.Queries.GetBudgetPlanSubTransactionCategories;

public class GetBudgetPlanSubTransactionCategoriesQueryHandler(ITransactionCategoryManager transactionCategoryManager)
	: IRequestHandler<GetBudgetPlanSubTransactionCategoriesQuery, SubTransactionCategoriesViewModel>
{
	public async Task<SubTransactionCategoriesViewModel> Handle(GetBudgetPlanSubTransactionCategoriesQuery request,
		CancellationToken cancellationToken)
	{
		return await transactionCategoryManager.GetSubTransactionCategoriesForBudgetPlan(request.BudgetPlanId,
			cancellationToken);
	}
}