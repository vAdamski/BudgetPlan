using BudgetPlan.Domain.Enums;

namespace BudgetPlan.Shared.Dtos;

public class AddOverTransactionCategoryDto
{
    public Guid BudgetPlanId { get; set; }
    public string Name { get; set; }
    public TransactionType TransactionType { get; set; }
}