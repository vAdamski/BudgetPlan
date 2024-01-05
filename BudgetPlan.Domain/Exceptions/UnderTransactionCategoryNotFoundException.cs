namespace BudgetPlan.Domain.Exceptions;

public class UnderTransactionCategoryNotFoundException : Exception
{
    public UnderTransactionCategoryNotFoundException(Guid guid) 
        : base($"Under transaction category with Id = {guid} has not")
    {
        
    }
}