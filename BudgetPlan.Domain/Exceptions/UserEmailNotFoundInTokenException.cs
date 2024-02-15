namespace BudgetPlan.Domain.Exceptions;

public class UserEmailNotFoundInTokenException : ExceptionBase
{
    public UserEmailNotFoundInTokenException(string message) : base(message)
    {
    }
}