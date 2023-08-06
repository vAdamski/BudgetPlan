namespace BudgetPlan.Shared.Dtos;

public class BudgetPlanUnderTransactionCategoryDto
{
    public int UnderCategoryId { get; set; }
    public string UnderCategoryName { get; set; }
    public BudgetPlanDetailsDto BudgetPlanDetailsDto { get; set; }
}