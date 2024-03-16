using BudgetPlan.Domain.Common;
using BudgetPlan.Domain.Exceptions;

namespace BudgetPlan.Domain.Entities;

public class BudgetPlanBase : AuditableEntity
{
    private BudgetPlanBase() { }
    
    public BudgetPlanBase(int year, int month, string baseUserEmail)
    {
        if (year == 0)
            throw new YearNullOrEmptyException();
        
        if (month == 0)
            throw new MonthNullOrEmptyException();
        
        if (string.IsNullOrEmpty(baseUserEmail))
            throw new BaseUserEmailNullOrEmptyException();
        
        DateFrom = new DateTime(year, month, 1);
        DateTo = DateFrom.AddMonths(1).AddDays(-1);

        var access = Access.Create();
        access.AddPerson(baseUserEmail);
        Access = access;
    }
    
    public DateTime DateFrom { get; private set; }
    public DateTime DateTo { get; private set; }
    
    public List<BudgetPlanDetails> BudgetPlanDetailsList { get; set; } = new();
    
    public Guid BudgetPlanId { get; private set; }
    public BudgetPlan BudgetPlan { get; private set; }
    
    public Guid? AccessId { get; set; }
    public Access? Access { get; set; }
}