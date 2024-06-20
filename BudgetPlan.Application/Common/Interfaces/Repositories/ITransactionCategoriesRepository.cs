using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Application.Common.Interfaces.Repositories;

public interface ITransactionCategoriesRepository
{
	Task<TransactionCategory> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
	Task<List<TransactionCategory>> GetAllTransactionCategories(CancellationToken cancellationToken = default);
	Task<TransactionCategory> GetOverTransactionCategoryAsync(Guid id, CancellationToken cancellationToken = default);
	Task<TransactionCategory> GetOverTransactionCategoryWithTransactionDetailsByIdAsync(Guid id,
		CancellationToken cancellationToken = default);
	Task<List<BudgetPlanEntity>> GetTransactionCategoriesForBudgetPlansAsync(CancellationToken cancellationToken = default);

	Task<List<TransactionCategory>> GetAllTransactionCategoriesWithTransactionDetails(
		CancellationToken cancellationToken = default);
	Task UpdateAsync(TransactionCategory transactionCategory, CancellationToken cancellationToken = default);
	Task UpdateRangeAsync(List<TransactionCategory> transactionCategories, CancellationToken cancellationToken = default);
	Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}