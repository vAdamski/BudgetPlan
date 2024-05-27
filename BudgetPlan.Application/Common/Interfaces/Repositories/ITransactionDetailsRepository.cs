using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Application.Common.Interfaces.Repositories;

public interface ITransactionDetailsRepository
{
	Task<List<TransactionDetail>> GetTransactionsForCategoriesBetweenDaysAsync(List<Guid> subCategoryIds, DateOnly dateFrom, DateOnly dateTo, CancellationToken cancellationToken = default);
}