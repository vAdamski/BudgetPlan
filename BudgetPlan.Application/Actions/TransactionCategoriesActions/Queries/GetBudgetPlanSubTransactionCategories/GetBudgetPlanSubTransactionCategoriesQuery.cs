using BudgetPlan.Shared.Dtos;
using BudgetPlan.Shared.ViewModels;
using MediatR;

namespace BudgetPlan.Application.Actions.TransactionCategoriesActions.Queries.GetBudgetPlanSubTransactionCategories;

public class GetBudgetPlanSubTransactionCategoriesQuery : IRequest<SubTransactionCategoriesViewModel>
{
	public Guid BudgetPlanId { get; }

	public GetBudgetPlanSubTransactionCategoriesQuery(Guid budgetPlanId)
	{
		BudgetPlanId = budgetPlanId;
	}
}