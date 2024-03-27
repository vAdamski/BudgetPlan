using BudgetPlan.Domain.Common;
using BudgetPlan.Domain.Enums;
using BudgetPlan.Domain.Exceptions;

namespace BudgetPlan.Domain.Entities;

public class BudgetPlanBase : AuditableEntity
{
    public DateOnly DateFrom { get; private set; }
    public DateOnly DateTo { get; private set; }
    
    public List<BudgetPlanDetails> BudgetPlanDetailsList { get; set; } = new();
    
    public Guid BudgetPlanEntityId { get; private set; }
    public BudgetPlanEntity BudgetPlanEntity { get; private set; }
    
    public Guid? AccessId { get; set; }
    public Access? Access { get; set; }
    
    private BudgetPlanBase() { }
    
    public BudgetPlanBase(DateOnly dateFrom, DateOnly dateTo, BudgetPlanEntity budgetPlanEntity)
    {
        if (dateFrom > dateTo)
        {
            throw new InvalidDateRangeException();
        }
        
        BudgetPlanEntityId = budgetPlanEntity.Id;
        BudgetPlanEntity = budgetPlanEntity;
        
        AccessId = budgetPlanEntity.AccessId;
        Access = budgetPlanEntity.Access;
        
        DateFrom = dateFrom;
        DateTo = dateTo;
    }
    
    public void AddBudgetPlanDetail(Guid categoryId)
    {
        var budgetPlanDetail = new BudgetPlanDetails
        {
            ExpectedAmount = 0,
            BudgetPlanType = BudgetPlanType.Monthly,
            BudgetPlanBaseId = Id,
            TransactionCategoryId = categoryId
        };
        
        BudgetPlanDetailsList.Add(budgetPlanDetail);
    }
}