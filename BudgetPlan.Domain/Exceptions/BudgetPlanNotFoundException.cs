namespace BudgetPlan.Domain.Exceptions;

public class BudgetPlanNotFoundException : Exception
{
    public BudgetPlanNotFoundException(Guid id) : base($"Budget plan with id {id} was not found") { }
}