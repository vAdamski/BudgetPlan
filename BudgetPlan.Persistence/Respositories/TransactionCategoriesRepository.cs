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
		var data = await context.TransactionCategories
			.Include(x => x.Access)
			.ThenInclude(x => x.AccessedPersons)
			.FirstOrDefaultAsync(x => x.Id == id &&
			                          x.StatusId == 1 &&
			                          x.Access.AccessedPersons.Any(x => x.Email == currentUserService.Email),
				cancellationToken);

		if (data == null)
			throw new NotFoundException(nameof(TransactionCategory), id);

		return data;
	}

	public async Task<List<BudgetPlanEntity>> GetTransactionCategoriesForBudgetPlansAsync(
		CancellationToken cancellationToken = default)
	{
		return await context.BudgetPlanEntities
			.Include(x => x.TransactionCategories)
			.ThenInclude(x => x.SubTransactionCategories.Where(sub => sub.StatusId == 1))
			.Include(x => x.DataAccess)
			.ThenInclude(x => x.AccessedPersons)
			.Where(x => x.StatusId == 1 &&
			            x.DataAccess.AccessedPersons.Any(x => x.Email == currentUserService.Email))
			.ToListAsync(cancellationToken);
	}

	public async Task<List<TransactionCategory>>
		GetOverTransactionCategoriesWithSubTransactionCategoriesForBudgetPlanAsync(
			Guid budgetPlanId, CancellationToken cancellationToken = default)
	{
		return await context.TransactionCategories
			.Include(x => x.SubTransactionCategories)
			.Include(x => x.Access)
			.ThenInclude(x => x.AccessedPersons)
			.Where(x => x.StatusId == 1 &&
			            x.BudgetPlanId == budgetPlanId &&
			            x.OverTransactionCategoryId == null &&
			            x.Access.AccessedPersons.Any(x => x.Email == currentUserService.Email))
			.ToListAsync(cancellationToken);
	}

	public async Task<bool> IsOverTransactionCategoryAsync(Guid transactionCategoryId,
		CancellationToken cancellationToken = default)
	{
		var data = await GetByIdAsync(transactionCategoryId, cancellationToken);

		return data.IsOverCategory;
	}

	public async Task<TransactionCategory> GetSubTransactionWithTransactionDetailsByIdAsync(Guid transactionCategoryId,
		CancellationToken cancellationToken = default)
	{
		return await context.TransactionCategories
			.Include(x => x.BudgetPlanDetails)
			.Include(x => x.Access)
			.ThenInclude(x => x.AccessedPersons)
			.Include(x => x.TransactionDetails)
			.FirstOrDefaultAsync(x => x.Id == transactionCategoryId &&
			                          x.StatusId == 1 &&
			                          x.Access.AccessedPersons.Any(x => x.Email == currentUserService.Email),
				cancellationToken);
	}

	public async Task<TransactionCategory> GetOverTransactionCategoryAsync(Guid id,
		CancellationToken cancellationToken = default)
	{
		var overTransactionCategory = await context
			.TransactionCategories
			.Include(x => x.SubTransactionCategories)
			.Include(x => x.Access)
			.ThenInclude(x => x.AccessedPersons)
			.FirstOrDefaultAsync(x => x.Id == id &&
			                          x.StatusId == 1 &&
			                          x.Access.AccessedPersons.Any(x => x.Email == currentUserService.Email) &&
			                          x.OverTransactionCategoryId == null
				, cancellationToken);

		if (overTransactionCategory == null)
			throw new NotFoundException(nameof(TransactionCategory), id);

		return overTransactionCategory;
	}

	public async Task<TransactionCategory> GetOverTransactionCategoryWithTransactionDetailsByIdAsync(Guid id,
		CancellationToken cancellationToken = default)
	{
		var data = await context.TransactionCategories
			.Include(x => x.SubTransactionCategories)
			.ThenInclude(x => x.BudgetPlanDetails)
			.Include(x => x.TransactionDetails)
			.Include(x => x.Access)
			.ThenInclude(x => x.AccessedPersons)
			.FirstOrDefaultAsync(x => x.StatusId == 1 &&
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

	public async Task DeleteAsync(TransactionCategory transactionCategory,
		CancellationToken cancellationToken = default)
	{
		TransactionCategory? transactionCategoryToDelete =
			await context.TransactionCategories.FirstOrDefaultAsync(x => x.Id == transactionCategory.Id,
				cancellationToken);
		
		if (transactionCategoryToDelete == null)
			throw new NotFoundException(nameof(TransactionCategory), transactionCategory.Id);

		transactionCategoryToDelete.StatusId = 0;
		transactionCategoryToDelete.InactivatedBy = currentUserService.Email;
		transactionCategoryToDelete.Inactivated = DateTime.Now;

		context.TransactionCategories.Update(transactionCategoryToDelete);

		await context.SaveChangesAsync(cancellationToken);
	}

	public async Task<List<TransactionCategory>> GetSubTransactionCategoriesForBudgetPlanAsync(Guid budgetPlanId,
		CancellationToken cancellationToken = default)
	{
		var data = await context.TransactionCategories
			.Include(x => x.Access)
			.ThenInclude(x => x.AccessedPersons)
			.Where(x => x.StatusId == 1 &&
			            x.BudgetPlanId == budgetPlanId &&
			            x.OverTransactionCategoryId != null &&
			            x.Access.AccessedPersons.Any(x => x.Email == currentUserService.Email))
			.ToListAsync(cancellationToken);

		return data;
	}
}