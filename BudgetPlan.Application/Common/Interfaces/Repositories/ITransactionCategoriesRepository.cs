using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Application.Common.Interfaces.Repositories;

public interface ITransactionCategoriesRepository
{
	Task<List<TransactionCategory>> GetAllTransactionCategories(CancellationToken cancellationToken = default);
	Task<TransactionCategory> GetOverTransactionCategoryAsync(Guid id, CancellationToken cancellationToken = default);
	Task UpdateAsync(TransactionCategory otc, CancellationToken cancellationToken = default);
}