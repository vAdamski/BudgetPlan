using BudgetPlan.Domain.Common;
using BudgetPlan.Shared.Enums;

namespace BudgetPlan.Domain.Entities;

public class BudgetPlanDetails : AuditableEntity
{
    public float Value { get; set; } = 0f;
    public string Description { get; set; } = "";
    public BudgetPlanType BudgetPlanType { get; set; }
    public int? BudgetPlanId { get; set; }
    public BudgetPlan BudgetPlan { get; set; }
    public int? TransactionCategoryId { get; set; }
    public TransactionCategory TransactionCategory { get; set; }
    
    public List<TransactionDetail> TransactionDetails { get; set; } = new();
}