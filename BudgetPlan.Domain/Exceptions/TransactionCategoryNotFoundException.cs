namespace BudgetPlan.Domain.Exceptions;

public class TransactionCategoryNotFoundException : Exception
{
    public TransactionCategoryNotFoundException(int transactionCategoryId) 
        : base($"Transaction category with Id = {transactionCategoryId} has not been found for this user!")
    {
        
    }
}