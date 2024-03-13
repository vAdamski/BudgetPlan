namespace BudgetPlan.Domain.Exceptions;

public class BudgetPlanNotFoundException : ExceptionBase
{
    public BudgetPlanNotFoundException(Guid id) : base($"Budget plan with id {id} was not found") { }
}