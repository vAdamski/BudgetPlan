using BudgetPlan.Shared.Enums;

namespace BudgetPlan.Shared.Dtos;

public class OverTransactionCategoryDto
{
    public int Id { get; set; }
    public string TransactionCategoryName { get; set; }
    public List<TransactionCategoryDto> TransactionCategoryDtos { get; set; } = new();
}