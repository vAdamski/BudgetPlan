namespace BudgetPlan.Domain.Exceptions;

public class BudgetPlanDetailNotFoundException : ExceptionBase
{
    public BudgetPlanDetailNotFoundException(Guid id) : base($"Budget plan detail with id {id} was not found")
    {
    }
}