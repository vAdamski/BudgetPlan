namespace BudgetPlan.Domain.Exceptions;

public class OverTransactionCategoryNotFoundException : ExceptionBase
{
    public OverTransactionCategoryNotFoundException(string message) : base(message) { }
}