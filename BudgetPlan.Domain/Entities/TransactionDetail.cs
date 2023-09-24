using BudgetPlan.Domain.Common;

namespace BudgetPlan.Domain.Entities;

public class TransactionDetail : AuditableEntity
{
    public double Value { get; set; }
    public string Description { get; set; } = "";
    public DateTime TransactionDate { get; set; }
    public Guid TransactionCategoryId { get; set; }
    public TransactionCategory TransactionCategory { get; set; }
}