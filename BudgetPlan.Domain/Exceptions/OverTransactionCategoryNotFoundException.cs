namespace BudgetPlan.Domain.Exceptions;

public class OverTransactionCategoryNotFoundException : Exception
{
    public OverTransactionCategoryNotFoundException(Guid overTransactionCategoryId)
        : base($"TransactionCategory with Id = {overTransactionCategoryId} has not been found for this user!") 
    { }
}