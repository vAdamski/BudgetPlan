namespace BudgetPlan.Domain.Exceptions;

public class TransactionCategoryMigrateToCannotBeUnderTransactionCategoryToDeleteException : ExceptionBase
{
    public TransactionCategoryMigrateToCannotBeUnderTransactionCategoryToDeleteException() : base(
        "Destination transaction category cannot be under the transaction category to delete.")
    {
    }
}