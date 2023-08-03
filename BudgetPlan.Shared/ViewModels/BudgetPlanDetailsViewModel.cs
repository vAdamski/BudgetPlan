using BudgetPlan.Shared.Dtos;

namespace BudgetPlan.Shared.ViewModels;

public class BudgetPlanDetailsViewModel
{
    public List<OverTransactionCategoryWithDetailsDto> OverTransactionCategoryWithDetailsDtos { get; set; } = new();
}