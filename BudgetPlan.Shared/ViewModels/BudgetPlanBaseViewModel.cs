using BudgetPlan.Shared.Dtos;

namespace BudgetPlan.Shared.ViewModels;

public class BudgetPlanBaseViewModel
{
	public Guid BudgetPlanBaseId { get; set; }
	public List<TransactionCategoryDetailsViewDto> TransactionCategoryDetailsViewDtos { get; set; } = new();
}