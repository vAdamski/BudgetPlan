using BudgetPlan.Domain.Common;

namespace BudgetPlan.Domain.Entities;

public class BudgetPlan : AuditableEntity
{
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public List<BudgetPlanDetails> BudgetPlanDetailsList { get; set; } = new();
}