namespace BudgetPlan.Application.Common.Interfaces.Managers;

public interface ITransactionCategoryManager
{
	Task<Guid> AddTransactionCategoryAsync(Guid overTransactionCategoryId,
		string categoryName, CancellationToken cancellationToken = default);
}