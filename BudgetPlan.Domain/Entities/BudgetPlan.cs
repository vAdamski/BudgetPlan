using BudgetPlan.Domain.Common;
using BudgetPlan.Domain.Exceptions;

namespace BudgetPlan.Domain.Entities;

public class BudgetPlan : AuditableEntity
{
    private List<BudgetPlanBase> _budgetPlanBases = new();
    
    public string Name { get; private set; }
    public IReadOnlyCollection<BudgetPlanBase> BudgetPlanBases => _budgetPlanBases.AsReadOnly();
    
    public Guid AccessId { get; private set; }
    public Access Access { get; private set; }
    
    
    private BudgetPlan()
    {
        
    }

    public static BudgetPlan Create(string name, string email)
    {
        if (string.IsNullOrEmpty(name))
            throw new BudgetPlanNameNullOrEmptyException();
        
        var budgetPlan = new BudgetPlan
        {
            Name = name,
            Access = Access.Create(email)
        };

        return budgetPlan;
    }
}