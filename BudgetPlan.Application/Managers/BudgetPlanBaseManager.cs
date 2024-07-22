using BudgetPlan.Application.Common.Interfaces.Builders;
using BudgetPlan.Application.Common.Interfaces.Managers;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Common.Extension;
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
		if (budgetPlanBaseId.IsNullOrEmpty())
			throw new ArgumentException("BudgetPlanBaseId cannot be null or empty.");
		
		return await budgetPlanBaseViewModelBuilder.Create(budgetPlanBaseId, cancellationToken);
	}

	public async Task<BudgetPlanBasesListViewModel> GetBudgetPlanBasesForBudgetPlanAsync(Guid requestBudgetPlanId,
		CancellationToken cancellationToken = default)
	{
		if (requestBudgetPlanId.IsNullOrEmpty())
			throw new ArgumentException("RequestBudgetPlanId cannot be null or empty.");
		
		List<BudgetPlanBase> budgetPlanBases =
			await budgetPlanBaseRepository.GetBudgetPlanBasesForBudgetPlanAsync(requestBudgetPlanId, cancellationToken);
		
		BudgetPlanBasesListViewModel budgetPlanBasesListViewModel = new(budgetPlanBases);

		return budgetPlanBasesListViewModel;
	}
}