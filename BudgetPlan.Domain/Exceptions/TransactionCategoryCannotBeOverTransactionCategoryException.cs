namespace BudgetPlan.Domain.Exceptions;

public class TransactionCategoryCannotBeOverTransactionCategoryException : ExceptionBase
{
    public TransactionCategoryCannotBeOverTransactionCategoryException(string message) : base(message)
    {
    }
}