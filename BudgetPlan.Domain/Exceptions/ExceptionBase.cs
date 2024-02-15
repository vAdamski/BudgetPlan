namespace BudgetPlan.Domain.Exceptions;

public abstract class ExceptionBase : Exception
{
    public ExceptionBase(string message) : base(message) { }
}