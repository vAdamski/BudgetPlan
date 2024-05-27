namespace BudgetPlan.Domain.Exceptions;

public class AccessEmailNullOrEmptyException : ExceptionBase
{
    public AccessEmailNullOrEmptyException() : base("Email cannot be null or empty.")
    {
    }
}