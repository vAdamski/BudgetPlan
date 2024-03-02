namespace BudgetPlan.Domain.Exceptions;

public class AccessIdNullOrEmptyException : Exception
{
    public AccessIdNullOrEmptyException() : base("Id cannot be null or empty.")
    {
    }
}