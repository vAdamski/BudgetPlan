namespace BudgetPlan.Domain.Exceptions;

public class InvalidDateRangeException() : Exception("Invalid date range. DateFrom must be less than DateTo.")
{
    
}