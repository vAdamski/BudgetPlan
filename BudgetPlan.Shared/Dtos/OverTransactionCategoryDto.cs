using BudgetPlan.Shared.Enums;

namespace BudgetPlan.Shared.Dtos;

public class OverTransactionCategoryDto
{
    public Guid Id { get; set; }
    public string TransactionCategoryName { get; set; }
    public List<TransactionCategoryDto> TransactionCategoryDtos { get; set; } = new();
}