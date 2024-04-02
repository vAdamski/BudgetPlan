using BudgetPlan.Domain.Common;
using BudgetPlan.Domain.Enums;
using BudgetPlan.Domain.Exceptions;

namespace BudgetPlan.Domain.Entities;

public class BudgetPlanBase : AuditableEntity
{
    private List<BudgetPlanDetails> _budgetPlanDetailsList = new();
    
    public DateOnly DateFrom { get; }
    public DateOnly DateTo { get; }
    
    public Guid? BudgetPlanEntityId { get; }
    public BudgetPlanEntity? BudgetPlanEntity { get; }
    
    public Guid? DataAccessId { get; }
    public DataAccess? DataAccess { get; }
    
    public IReadOnlyCollection<BudgetPlanDetails> BudgetPlanDetailsList => _budgetPlanDetailsList.AsReadOnly();
    
    private BudgetPlanBase() { }
    
    public BudgetPlanBase(DateOnly dateFrom, DateOnly dateTo, Guid budgetPlanEntityId, Guid dataAccessId)
    {
        if (dateFrom > dateTo)
            throw new InvalidDateRangeException();
        
        BudgetPlanEntityId = budgetPlanEntityId;
        
        DataAccessId = dataAccessId;
        
        DateFrom = dateFrom;
        DateTo = dateTo;
    }
    
    public void AddBudgetPlanDetail(Guid categoryId)
    {
        if (DataAccessId == null)
            throw new AccessIdNullOrEmptyException();
        
        var budgetPlanDetail = new BudgetPlanDetails(0, BudgetPlanType.Monthly, Id, categoryId, DataAccessId.Value);
        
        _budgetPlanDetailsList.Add(budgetPlanDetail);
    }
}