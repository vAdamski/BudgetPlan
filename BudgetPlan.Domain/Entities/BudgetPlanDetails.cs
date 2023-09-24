using BudgetPlan.Domain.Common;
using BudgetPlan.Shared.Enums;

namespace BudgetPlan.Domain.Entities;

public class BudgetPlanDetails : AuditableEntity
{
    public double ExpectedAmount { get; set; } = 0f;
    public BudgetPlanType BudgetPlanType { get; set; }
    public int? BudgetPlanBaseId { get; set; }
    public BudgetPlanBase BudgetPlanBase { get; set; }
    public int? TransactionCategoryId { get; set; }
    public TransactionCategory TransactionCategory { get; set; }
}