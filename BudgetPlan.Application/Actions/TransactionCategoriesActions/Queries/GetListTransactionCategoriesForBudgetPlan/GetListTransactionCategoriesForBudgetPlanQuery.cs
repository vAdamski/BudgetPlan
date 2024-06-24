using BudgetPlan.Shared.ViewModels;
using MediatR;

namespace BudgetPlan.Application.Actions.TransactionCategoriesActions.Queries.GetListTransactionCategoriesForBudgetPlan;

public class GetListTransactionCategoriesForBudgetPlanQuery : IRequest<TransactionCategoriesForBudgetPlanViewModel>
{
	public Guid BudgetPlanId { get; }

	public GetListTransactionCategoriesForBudgetPlanQuery(Guid budgetPlanId)
	{
		BudgetPlanId = budgetPlanId;
	}
}