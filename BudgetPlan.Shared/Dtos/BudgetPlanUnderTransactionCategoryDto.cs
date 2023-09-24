namespace BudgetPlan.Shared.Dtos;

public class BudgetPlanUnderTransactionCategoryDto
{
    public Guid UnderCategoryId { get; set; }
    public string UnderCategoryName { get; set; }
    public BudgetPlanDetailsDto BudgetPlanDetailsDto { get; set; }
}