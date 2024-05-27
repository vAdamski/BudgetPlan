using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Application.Common.Interfaces.Repositories;

public interface ITransactionCategoriesRepository
{
	Task<TransactionCategory> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
	Task<List<TransactionCategory>> GetAllTransactionCategories(CancellationToken cancellationToken = default);
	Task<TransactionCategory> GetOverTransactionCategoryAsync(Guid id, CancellationToken cancellationToken = default);
	Task UpdateAsync(TransactionCategory otc, CancellationToken cancellationToken = default);
}