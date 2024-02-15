namespace BudgetPlan.Domain.Exceptions;

public class TransactionCategoryMigrateToCannotBeUnderTransactionCategoryToDeleteException : ExceptionBase
{
    public TransactionCategoryMigrateToCannotBeUnderTransactionCategoryToDeleteException(string message) : base(message)
    {   
    }
}