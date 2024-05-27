using BudgetPlan.Shared.ViewModels;
using MediatR;

namespace BudgetPlan.Application.Actions.BudgetPlanBaseActions.Queries.GetBudgetPlanView;

public class GetBudgetPlanViewQuery : IRequest<BudgetPlanBaseViewModel>
{
	public Guid BudgetPlanBaseId { get; }

	public GetBudgetPlanViewQuery(Guid budgetPlanBaseId)
	{
		BudgetPlanBaseId = budgetPlanBaseId;
	}
}