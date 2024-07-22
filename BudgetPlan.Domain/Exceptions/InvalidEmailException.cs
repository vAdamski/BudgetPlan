namespace BudgetPlan.Domain.Exceptions;

public class InvalidEmailException(string email) : Exception($"Invalid email: {email}")
{
	
}