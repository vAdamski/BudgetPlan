namespace BudgetPlan.Domain.Exceptions;

public class UserEmailNotFoundInTokenException : Exception
{
    public UserEmailNotFoundInTokenException() : base($"User email was not found in token.") { }
}