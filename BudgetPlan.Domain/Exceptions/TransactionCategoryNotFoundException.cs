namespace BudgetPlan.Domain.Exceptions;

public class TransactionCategoryNotFoundException : ExceptionBase
{
    public TransactionCategoryNotFoundException(string message) : base(message)
    {
    }
}