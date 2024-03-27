using BudgetPlan.Domain.Common;
using BudgetPlan.Domain.Exceptions;

namespace BudgetPlan.Domain.Entities;

public class BudgetPlanEntity : AuditableEntity
{
    private List<BudgetPlanBase> _budgetPlanBases = new();
    
    public string Name { get; private set; }
    public IReadOnlyCollection<BudgetPlanBase> BudgetPlanBases => _budgetPlanBases.AsReadOnly();
    
    public Guid AccessId { get; private set; }
    public Access Access { get; private set; }
    
    
    private BudgetPlanEntity()
    {
        
    }

    public static BudgetPlanEntity Create(string name, string email)
    {
        if (string.IsNullOrEmpty(name))
            throw new BudgetPlanNameNullOrEmptyException();
        
        var access = Access.Create(email);
        
        var budgetPlan = new BudgetPlanEntity
        {
            Name = name,
            AccessId = access.Id,
            Access = access,
        };

        return budgetPlan;
    }
    
    public BudgetPlanBase AddBudgetPlanBase(DateOnly dateFrom, DateOnly dateTo)
    {
        var budgetPlanBase = new BudgetPlanBase(dateFrom, dateTo, this);
        _budgetPlanBases.Add(budgetPlanBase);
        return budgetPlanBase;
    }
}