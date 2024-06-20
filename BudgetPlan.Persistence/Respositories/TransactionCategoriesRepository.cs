using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlan.Persistence.Respositories;

public class TransactionCategoriesRepository(
	IBudgetPlanDbContext context,
	ICurrentUserService currentUserService)
	: ITransactionCategoriesRepository
{
	public async Task<TransactionCategory> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
	{
		return await context.TransactionCategories
			.Include(x => x.Access)
			.ThenInclude(x => x.AccessedPersons)
			.FirstOrDefaultAsync(x =>
					x.Access.AccessedPersons.Any(x => x.Email == currentUserService.Email) &&
					x.Id == id,
				cancellationToken);
	}

	public async Task<List<TransactionCategory>> GetAllTransactionCategories(
		CancellationToken cancellationToken = default)
	{
		return await context.TransactionCategories
			.Include(tc => tc.SubTransactionCategories)
			.Include(tc => tc.Access)
			.ThenInclude(x => x.AccessedPersons)
			.Where(x => x.Access.AccessedPersons.Any(x => x.Email == currentUserService.Email))
			.ToListAsync(cancellationToken);
	}

	public async Task<List<BudgetPlanEntity>> GetTransactionCategoriesForBudgetPlansAsync(
		CancellationToken cancellationToken = default)
	{
		return await context.BudgetPlanEntities
			.Include(x => x.TransactionCategories)
			.ThenInclude(x => x.SubTransactionCategories)
			.Include(x => x.DataAccess)
			.ThenInclude(x => x.AccessedPersons)
			.Where(x => x.DataAccess.AccessedPersons.Any(x => x.Email == currentUserService.Email))
			.ToListAsync();
	}

	public async Task<List<TransactionCategory>> GetAllTransactionCategoriesWithTransactionDetails(
		CancellationToken cancellationToken = default)
	{
		return await context.TransactionCategories
			.Include(tc => tc.SubTransactionCategories)
			.ThenInclude(stc => stc.TransactionDetails)
			.Include(tc => tc.Access)
			.ThenInclude(x => x.AccessedPersons)
			.Where(x => x.Access.AccessedPersons.Any(x => x.Email == currentUserService.Email))
			.ToListAsync(cancellationToken);
	}

	public async Task<TransactionCategory> GetOverTransactionCategoryAsync(Guid id,
		CancellationToken cancellationToken = default)
	{
		var overTransactionCategory = await context
			.TransactionCategories
			.Include(x => x.SubTransactionCategories)
			.Include(x => x.Access)
			.ThenInclude(x => x.AccessedPersons)
			.FirstOrDefaultAsync(x =>
				x.Access.AccessedPersons.Any(x => x.Email == currentUserService.Email) &&
				x.OverTransactionCategoryId == null, cancellationToken);

		if (overTransactionCategory == null)
			throw new NotFoundException(nameof(TransactionCategory), id);

		return overTransactionCategory;
	}

	public async Task<TransactionCategory> GetOverTransactionCategoryWithTransactionDetailsByIdAsync(Guid id,
		CancellationToken cancellationToken = default)
	{
		var data = await context.TransactionCategories
			.Include(x => x.SubTransactionCategories)
			.Include(x => x.TransactionDetails)
			.Include(x => x.Access)
			.ThenInclude(x => x.AccessedPersons)
			.FirstOrDefaultAsync(x =>
				x.Access.AccessedPersons.Any(x => x.Email == currentUserService.Email) &&
				x.OverTransactionCategoryId == null && x.Id == id, cancellationToken);

		if (data == null)
			throw new NotFoundException(nameof(TransactionCategory), id);

		return data;
	}

	public async Task UpdateAsync(TransactionCategory transactionCategory,
		CancellationToken cancellationToken = default)
	{
		context.TransactionCategories.Update(transactionCategory);

		await context.SaveChangesAsync(cancellationToken);
	}

	public async Task UpdateRangeAsync(List<TransactionCategory> transactionCategories,
		CancellationToken cancellationToken = default)
	{
		context.TransactionCategories.UpdateRange(transactionCategories);

		await context.SaveChangesAsync(cancellationToken);
	}

	public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
	{
		var isOverTransactionCategory = await IsOverTransactionCategory(id, cancellationToken);

		TransactionCategory transactionCategoryToDelete;

		if (isOverTransactionCategory)
			transactionCategoryToDelete = await GetOverTransactionCategoryAsync(id, cancellationToken);
		else
			transactionCategoryToDelete = await GetByIdAsync(id, cancellationToken);
	}

	private async Task<bool> IsOverTransactionCategory(Guid id, CancellationToken cancellationToken = default)
	{
		var transactionCategory = await context.TransactionCategories.FindAsync(id);

		if (transactionCategory == null)
			throw new NotFoundException(nameof(TransactionCategory), id);

		return transactionCategory.IsOverCategory;
	}
}