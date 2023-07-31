using BudgetPlan.Domain.Common;

namespace BudgetPlan.Domain.Entities;

public class TransactionDetail : AuditableEntity
{
    public float Value { get; set; }
    public string Description { get; set; } = "";
    public DateTime TransactionDate { get; set; }
    public int TransactionCategoryId { get; set; }
}