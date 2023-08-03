using BudgetPlan.Shared.ViewModels;

namespace BudgetPlan.Shared.Dtos;

public class TransactionCategoryWithDetailsDto
{
    public int Id { get; set; }
    public string TransactionCategoryName { get; set; }
    public BudgetPlanDetailsForMonthDto PlanDetailsForMonthDto { get; set; }
    public List<TransactionItemDto> TransactionItems { get; set; } = new();
}