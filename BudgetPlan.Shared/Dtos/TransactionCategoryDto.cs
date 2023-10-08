using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Shared.Dtos;

public class TransactionCategoryDto
{
    public Guid Id { get; set; }
    public string TransactionCategoryName { get; set; }
}