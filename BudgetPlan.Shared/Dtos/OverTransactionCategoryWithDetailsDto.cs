using BudgetPlan.Shared.Enums;
using BudgetPlan.Shared.ViewModels;

namespace BudgetPlan.Shared.Dtos;

public class OverTransactionCategoryWithDetailsDto
{
    public int Id { get; set; }
    public string TransactionCategoryName { get; set; }
    public TransactionType TransactionType { get; set; }
    public List<TransactionCategoryWithDetailsDto> TransactionCategoryDtos { get; set; } = new();
}