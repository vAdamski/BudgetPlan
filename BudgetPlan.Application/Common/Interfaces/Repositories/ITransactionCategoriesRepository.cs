using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Application.Common.Interfaces.Repositories;

public interface ITransactionCategoriesRepository
{
	Task<TransactionCategory> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
	Task<TransactionCategory> GetOverTransactionCategoryAsync(Guid id, CancellationToken cancellationToken = default);

	Task<TransactionCategory> GetOverTransactionCategoryWithTransactionDetailsByIdAsync(Guid id,
		CancellationToken cancellationToken = default);

	Task<List<BudgetPlanEntity>> GetTransactionCategoriesForBudgetPlansAsync(
		CancellationToken cancellationToken = default);

	Task UpdateAsync(TransactionCategory transactionCategory, CancellationToken cancellationToken = default);

	Task DeleteAsync(TransactionCategory transactionCategory, CancellationToken cancellationToken = default);

	Task<List<TransactionCategory>> GetSubTransactionCategoriesForBudgetPlanAsync(Guid budgetPlanId,
		CancellationToken cancellationToken = default);

	Task<List<TransactionCategory>> GetOverTransactionCategoriesWithSubTransactionCategoriesForBudgetPlanAsync(
		Guid budgetPlanId, CancellationToken cancellationToken = default);

	Task<bool> IsOverTransactionCategoryAsync(Guid transactionCategoryId, CancellationToken cancellationToken = default);
	Task<TransactionCategory> GetSubTransactionWithTransactionDetailsByIdAsync(Guid transactionCategoryId, CancellationToken cancellationToken = default);
}