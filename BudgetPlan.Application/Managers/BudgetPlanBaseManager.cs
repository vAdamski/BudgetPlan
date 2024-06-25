using BudgetPlan.Application.Common.Interfaces.Builders;
using BudgetPlan.Application.Common.Interfaces.Managers;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Shared.ViewModels;

namespace BudgetPlan.Application.Managers;

public class BudgetPlanBaseManager(
	IBudgetPlanBaseViewModelBuilder budgetPlanBaseViewModelBuilder,
	IBudgetPlanBaseRepository budgetPlanBaseRepository) : IBudgetPlanBaseManager
{
	public async Task<BudgetPlanBaseViewModel> BuildDetailedViewModel(Guid budgetPlanBaseId,
		CancellationToken cancellationToken = default)
	{
		return await budgetPlanBaseViewModelBuilder.Create(budgetPlanBaseId, cancellationToken);
	}

	public async Task<BudgetPlanBasesListViewModel> GetBudgetPlanBasesForBudgetPlanAsync(Guid requestBudgetPlanId,
		CancellationToken cancellationToken = default)
	{
		List<BudgetPlanBase> budgetPlanBases =
			await budgetPlanBaseRepository.GetBudgetPlanBasesForBudgetPlanAsync(requestBudgetPlanId, cancellationToken);
		
		BudgetPlanBasesListViewModel budgetPlanBasesListViewModel = new(budgetPlanBases);

		return budgetPlanBasesListViewModel;
	}
}