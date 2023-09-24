using BudgetPlan.Domain.Common;

namespace BudgetPlan.Domain.Entities;

public class BudgetPlanBase : AuditableEntity
{
    public BudgetPlanBase() { }
    
    public BudgetPlanBase(int year, int month)
    {
        DateFrom = new DateTime(year, month, 1);
        DateTo = DateFrom.AddMonths(1).AddDays(-1);
    }
    
    public DateTime DateFrom { get; private set; }
    public DateTime DateTo { get; private set; }
    
    public List<BudgetPlanDetails> BudgetPlanDetailsList { get; set; } = new();
}