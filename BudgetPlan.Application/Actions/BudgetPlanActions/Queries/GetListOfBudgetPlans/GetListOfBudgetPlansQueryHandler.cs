using BudgetPlan.Application.Common.Interfaces.Managers;
using BudgetPlan.Shared.ViewModels;
using MediatR;

namespace BudgetPlan.Application.Actions.BudgetPlanActions.Queries.GetListOfBudgetPlans;

public class GetListOfBudgetPlansQueryHandler(IBudgetPlanManager budgetPlanManager) : IRequestHandler<GetListOfBudgetPlansQuery, BudgetPlanListViewModel>
{
	public async Task<BudgetPlanListViewModel> Handle(GetListOfBudgetPlansQuery request, CancellationToken cancellationToken)
	{
		return await budgetPlanManager.GetBudgetPlanListViewModel(cancellationToken);
	}
}