using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlan.Persistence.Respositories;

public class TransactionDetailsRepository(IBudgetPlanDbContext ctx) : ITransactionDetailsRepository
{
	public async Task<List<TransactionDetail>> GetTransactionsForCategoriesBetweenDaysAsync(List<Guid> subCategoryIds,
		DateOnly dateFrom, DateOnly dateTo,
		CancellationToken cancellationToken = default)
	{
		return await ctx.TransactionDetails.Where(x =>
				subCategoryIds.Contains(x.TransactionCategoryId.Value) &&
				x.TransactionDate >= dateFrom &&
				x.TransactionDate <= dateTo)
			.ToListAsync(cancellationToken);
	}
}