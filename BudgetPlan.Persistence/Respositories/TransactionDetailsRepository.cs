using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlan.Persistence.Respositories;

public class TransactionDetailsRepository(IBudgetPlanDbContext context, ICurrentUserService currentUserService)
	: ITransactionDetailsRepository
{
	public async Task<List<TransactionDetail>> GetTransactionsForCategoriesBetweenDaysAsync(List<Guid> subCategoryIds,
		DateOnly dateFrom, DateOnly dateTo,
		CancellationToken cancellationToken = default)
	{
		return await context.TransactionDetails.Where(x =>
				subCategoryIds.Contains(x.TransactionCategoryId.Value) &&
				x.TransactionDate >= dateFrom &&
				x.TransactionDate <= dateTo)
			.ToListAsync(cancellationToken);
	}

	public async Task<TransactionDetail> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
	{
		var response = await context.TransactionDetails
			.Include(x => x.Access)
			.ThenInclude(x => x.AccessedPersons)
			.FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);

		if (response == null)
			throw new NotFoundException(nameof(TransactionDetail), id);

		if (response.Access.IsAccessed(currentUserService.Email))
			throw new AccessDeniedException();

		return response;
	}

	public async Task UpdateAsync(TransactionDetail transactionDetail, CancellationToken cancellationToken = default)
	{
		context.TransactionDetails.Update(transactionDetail);

		await context.SaveChangesAsync(cancellationToken);
	}

	public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
	{
		var transactionDetail = await GetByIdAsync(id, cancellationToken);

		context.TransactionDetails.Remove(transactionDetail);

		await context.SaveChangesAsync(cancellationToken);
	}
}