using BudgetPlan.Application.Common.Interfaces.Managers;
using BudgetPlan.Shared.ViewModels;
using MediatR;

namespace BudgetPlan.Application.Actions.BudgetPlanBaseActions.Queries.GetBudgetPlanBasesForBudgetPlan;

public class GetBudgetPlanBasesForBudgetPlanQueryHandler(IBudgetPlanBaseManager budgetPlanBaseManager)
	: IRequestHandler<GetBudgetPlanBasesForBudgetPlanQuery, BudgetPlanBasesListViewModel>
{
	public async Task<BudgetPlanBasesListViewModel> Handle(GetBudgetPlanBasesForBudgetPlanQuery request,
		CancellationToken cancellationToken)
	{
		return await budgetPlanBaseManager.GetBudgetPlanBasesForBudgetPlanAsync(request.BudgetPlanId,
			cancellationToken);
	}
}