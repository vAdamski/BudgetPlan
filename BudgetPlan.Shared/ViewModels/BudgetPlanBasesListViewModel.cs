using BudgetPlan.Domain.Entities;
using BudgetPlan.Shared.Dtos;

namespace BudgetPlan.Shared.ViewModels;

public class BudgetPlanBasesListViewModel
{
	public List<BudgetPlanBaseDto> BudgetPlanBasesDtos { get; }

	public BudgetPlanBasesListViewModel(List<BudgetPlanBase> budgetPlanBases)
	{
		BudgetPlanBasesDtos = budgetPlanBases.Select(x => new BudgetPlanBaseDto(x)).ToList();
	}
}