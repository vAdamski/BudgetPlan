namespace BudgetPlan.Domain.Exceptions;

public class TransactionCategoryNotFoundException : ExceptionBase
{
    public TransactionCategoryNotFoundException(Guid id) : base($"Transaction category with Id = {id} has not been found!")
    {
    }
}