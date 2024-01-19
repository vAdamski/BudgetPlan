namespace BudgetPlan.Domain.Exceptions;

public class TransactionCategoryCannotBeOverTransactionCategoryException : Exception
{
    public TransactionCategoryCannotBeOverTransactionCategoryException(Guid transactionCategoryId)
        : base($"Transaction category with id {transactionCategoryId} is not under transaction category")
    {
    }
}