namespace BudgetPlan.Domain.Exceptions;

public class BudgetPlanDetailNotFoundException : ExceptionBase
{
    public BudgetPlanDetailNotFoundException(string message) : base(message)
    {
    }
}