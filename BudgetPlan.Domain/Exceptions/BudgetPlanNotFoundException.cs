namespace BudgetPlan.Domain.Exceptions;

public class BudgetPlanNotFoundException : ExceptionBase
{
    public BudgetPlanNotFoundException(string message) : base(message) { }
}