using BudgetPlan.Shared.ViewModels;
using MediatR;

namespace BudgetPlan.Application.Actions.BudgetPlanBaseActions.Queries.GetBudgetPlanBasesForBudgetPlan;

public class GetBudgetPlanBasesForBudgetPlanQuery : IRequest<BudgetPlanBasesListViewModel>
{
	public Guid BudgetPlanId { get; }
	
	public GetBudgetPlanBasesForBudgetPlanQuery(Guid budgetPlanId)
	{
		BudgetPlanId = budgetPlanId;
	}
}