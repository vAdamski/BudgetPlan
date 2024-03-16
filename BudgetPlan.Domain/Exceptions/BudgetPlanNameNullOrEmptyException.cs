namespace BudgetPlan.Domain.Exceptions;

public class BudgetPlanNameNullOrEmptyException : Exception
{
    public BudgetPlanNameNullOrEmptyException() : base("Budget plan name cannot be null or empty.")
    {
    }
}