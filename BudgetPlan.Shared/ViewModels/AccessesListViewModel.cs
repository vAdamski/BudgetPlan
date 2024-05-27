using BudgetPlan.Domain.Entities;
using BudgetPlan.Shared.Dtos;

namespace BudgetPlan.Shared.ViewModels;

public class AccessesListViewModel
{
	public List<AccessDetailsDto> AccessDetails { get; } = new();

	public AccessesListViewModel(List<BudgetPlanEntity> budgetPlans)
	{
		if (budgetPlans == null)
			throw new ArgumentException("Cannot be null!", nameof(List<BudgetPlanEntity>));

		AccessDetails = budgetPlans.Select(x => new AccessDetailsDto(x)).ToList();
	}
}