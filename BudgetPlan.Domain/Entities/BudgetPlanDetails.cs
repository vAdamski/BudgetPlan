using BudgetPlan.Domain.Common;
using BudgetPlan.Domain.Enums;

namespace BudgetPlan.Domain.Entities;

public class BudgetPlanDetails : AuditableEntity
{
    public double ExpectedAmount { get; set; } = 0f;
    public BudgetPlanType BudgetPlanType { get; set; }
    public Guid? BudgetPlanBaseId { get; set; }
    public BudgetPlanBase BudgetPlanBase { get; set; }
    public Guid? TransactionCategoryId { get; set; }
    public TransactionCategory TransactionCategory { get; set; }
    
    public Guid? AccessId { get; set; }
    public Access? Access { get; set; }
}