using BudgetPlan.Domain.Entities;
using BudgetPlan.Shared.Dtos;

namespace BudgetPlan.Shared.ViewModels;

public class BudgetPlanListViewModel
{
	public List<BudgetPlanDto> BudgetPlanDtos { get; } = new();

	public BudgetPlanListViewModel(List<BudgetPlanEntity> budgetPlanBases)
	{
		BudgetPlanDtos = budgetPlanBases.Select(b => new BudgetPlanDto(b)).ToList();
	}
}