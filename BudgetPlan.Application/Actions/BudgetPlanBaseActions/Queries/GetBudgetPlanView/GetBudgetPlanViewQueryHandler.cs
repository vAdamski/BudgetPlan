using BudgetPlan.Application.Common.Interfaces.Builders;
using BudgetPlan.Application.Common.Interfaces.Managers;
using BudgetPlan.Shared.ViewModels;
using MediatR;

namespace BudgetPlan.Application.Actions.BudgetPlanBaseActions.Queries.GetBudgetPlanView;

public class GetBudgetPlanViewQueryHandler(IBudgetPlanBaseManager manger) : IRequestHandler<
	GetBudgetPlanViewQuery, BudgetPlanBaseViewModel>
{
	public async Task<BudgetPlanBaseViewModel> Handle(GetBudgetPlanViewQuery request,
		CancellationToken cancellationToken)
	{
		return await manger.BuildDetailedViewModel(request.BudgetPlanBaseId, cancellationToken);
	}
}