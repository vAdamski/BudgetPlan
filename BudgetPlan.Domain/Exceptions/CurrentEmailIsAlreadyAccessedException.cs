namespace BudgetPlan.Domain.Exceptions;

public class CurrentEmailIsAlreadyAccessedException : Exception
{
    public CurrentEmailIsAlreadyAccessedException(string emial) : base($"Email {emial} is already accessed")
    {
        
    }
}