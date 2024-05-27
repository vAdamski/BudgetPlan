namespace BudgetPlan.Domain.Exceptions;

public class UnderTransactionCategoryNotFoundException : ExceptionBase
{
    public UnderTransactionCategoryNotFoundException(string message) : base(message)
    {
    }
}