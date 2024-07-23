using BudgetPlan.Domain.Common;
using BudgetPlan.Domain.Enums;
using BudgetPlan.Domain.Exceptions;

namespace BudgetPlan.Domain.Entities;

public class BudgetPlanDetails : AuditableEntity
{
    public double ExpectedAmount { get; private set; }
    public BudgetPlanType BudgetPlanType { get; private set; }
    
    public Guid BudgetPlanBaseId { get; private set; }
    public BudgetPlanBase? BudgetPlanBase { get; private set; }
    
    public Guid TransactionCategoryId { get; private set; }
    public TransactionCategory? TransactionCategory { get; private set; }
    
    public Guid DataAccessId { get; private set; }
    public DataAccess? DataAccess { get; private set; }
    
    private BudgetPlanDetails() { }

    public BudgetPlanDetails(double expectedAmount, BudgetPlanType budgetPlanType, Guid budgetPlanBaseId, Guid transactionCategoryId, Guid dataAccessId)
    {
        ExpectedAmount = expectedAmount;
        BudgetPlanType = budgetPlanType;
        BudgetPlanBaseId = budgetPlanBaseId;
        TransactionCategoryId = transactionCategoryId;
        DataAccessId = dataAccessId;
    }
    
    public void UpdateExpectedAmount(double expectedAmount)
    {
        if (expectedAmount < 0)
            throw new ExpectedAmountCannotBeNegativeException();
        
	    ExpectedAmount = expectedAmount;
    }
}