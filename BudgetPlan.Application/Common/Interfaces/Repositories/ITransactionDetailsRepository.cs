using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Application.Common.Interfaces.Repositories;

public interface ITransactionDetailsRepository
{
	Task<List<TransactionDetail>> GetTransactionsForCategoriesBetweenDaysAsync(List<Guid> subCategoryIds,
		DateOnly dateFrom, DateOnly dateTo, CancellationToken cancellationToken = default);

	Task<TransactionDetail> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
	Task UpdateAsync(TransactionDetail transactionDetail, CancellationToken cancellationToken = default);
	Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
	Task UpdateRangeAsync(List<TransactionDetail> items, CancellationToken cancellationToken = default);
	Task DeleteRangeAsync(List<TransactionDetail> transactionDetailsToDelete, CancellationToken cancellationToken = default);
}