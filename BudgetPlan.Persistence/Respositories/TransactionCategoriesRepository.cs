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

	public async Task UpdateAsync(TransactionCategory otc, CancellationToken cancellationToken = default)
	{
		context.TransactionCategories.Update(otc);

		await context.SaveChangesAsync(cancellationToken);
	}
}