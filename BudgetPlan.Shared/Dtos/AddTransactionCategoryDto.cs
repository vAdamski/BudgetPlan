namespace BudgetPlan.Shared.Dtos;

public class AddTransactionCategoryDto
{
    public Guid OverTransactionCategoryId { get; set; }
    public string CategoryName { get; set; } = "";
}