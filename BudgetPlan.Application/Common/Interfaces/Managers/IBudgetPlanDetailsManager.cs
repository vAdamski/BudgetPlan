namespace BudgetPlan.Application.Common.Interfaces.Managers;

public interface IBudgetPlanDetailsManager
{
	Task Update(Guid id, double expectedAmount, CancellationToken cancellationToken = default);
}