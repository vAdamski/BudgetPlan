using BudgetPlan.Application.Common.Interfaces.Builders;
using BudgetPlan.Application.Common.Interfaces.Managers;
using BudgetPlan.Shared.ViewModels;

namespace BudgetPlan.Application.Managers;

public class BudgetPlanBaseManager(IBudgetPlanBaseViewModelBuilder budgetPlanBaseViewModelBuilder) : IBudgetPlanBaseManager
{
	public async Task<BudgetPlanBaseViewModel> BuildDetailedViewModel(Guid budgetPlanBaseId,
		CancellationToken cancellationToken = default)
	{
		return await budgetPlanBaseViewModelBuilder.Create(budgetPlanBaseId, cancellationToken);
	}
}