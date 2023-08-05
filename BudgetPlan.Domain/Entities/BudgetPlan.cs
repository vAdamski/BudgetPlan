using BudgetPlan.Domain.Common;

namespace BudgetPlan.Domain.Entities;

public class BudgetPlan : AuditableEntity
{
    public BudgetPlan(int year, int month)
    {
        DateFrom = new DateTime(year, month, 1);
        DateTo = DateFrom.AddMonths(1).AddDays(-1);
    }
    
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    
    public List<BudgetPlanDetails> BudgetPlanDetailsList { get; set; } = new();
}