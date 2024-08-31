using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Common.Extension;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlan.Persistence.Respositories;

public class BudgetPlanRepository(IBudgetPlanDbContext ctx, ICurrentUserService currentUserService)
	: IBudgetPlanRepository
{
	public async Task<BudgetPlanEntity> Create(string name, CancellationToken cancellationToken = default)
	{
		var budgetPlan = BudgetPlanEntity.Create(name, currentUserService.Email);

		await ctx.BudgetPlanEntities.AddAsync(budgetPlan, cancellationToken);

		await ctx.SaveChangesAsync(cancellationToken);

		return budgetPlan;
	}

	public async Task UpdateAsync(BudgetPlanEntity budgetPlan, CancellationToken cancellationToken = default)
	{
		if (budgetPlan == null)
			throw new ArgumentNullException(nameof(budgetPlan));

		if (!budgetPlan.DataAccess.IsAccessed(currentUserService.Email))
			throw new AccessDeniedException();

		ctx.BudgetPlanEntities.Update(budgetPlan);

		await ctx.SaveChangesAsync(cancellationToken);
	}

	public async Task<BudgetPlanEntity> GetBudgetPlanBaseWithDetailsByIdAsync(Guid budgetPlanId, Guid? budgetPlanBaseId,
		CancellationToken cancellationToken = default)
	{
		if (budgetPlanId.IsNullOrEmpty())
			throw new ArgumentException("Id is null or empty", nameof(budgetPlanId));
		
		if (budgetPlanBaseId.IsNullOrEmpty())
			throw new ArgumentException("Id is null or empty", nameof(budgetPlanBaseId));
		
		var budgetPlanBase = await ctx.BudgetPlanBases.FirstOrDefaultAsync(x => x.Id == budgetPlanBaseId, cancellationToken);
		
		if (budgetPlanBase == null)
			throw new NotFoundException(nameof(BudgetPlanBase), budgetPlanBaseId);

		// TransactionDetail TransactionDate is between budgetPlanBase.DateFrom and budgetPlanBase.DateTo
		var budgetPlan = await ctx.BudgetPlanEntities
			.Where(x => x.Id == budgetPlanId && x.StatusId == 1)
			.Include(x => x.DataAccess)
			.ThenInclude(x => x.AccessedPersons.Where(x => x.StatusId == 1))
			.Include(x => x.TransactionCategories.Where(x => x.OverTransactionCategoryId == null && x.StatusId == 1))
			.ThenInclude(x => x.SubTransactionCategories.Where(x => x.StatusId == 1))
			.ThenInclude(x => x.TransactionDetails
				.Where(td => td.TransactionDate >= budgetPlanBase.DateFrom && 
				             td.TransactionDate <= budgetPlanBase.DateTo &&
				             td.StatusId == 1))
			.FirstOrDefaultAsync();
			

		if (budgetPlan == null)
			throw new NotFoundException(nameof(BudgetPlanEntity), budgetPlanId);

		if (!budgetPlan.DataAccess.IsAccessed(currentUserService.Email))
			throw new AccessDeniedException();

		return budgetPlan;
	}

	public async Task<BudgetPlanEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
	{
		if (id.IsNullOrEmpty())
			throw new ArgumentException("Id is null or empty", nameof(id));

		var budgetPlan = await ctx.BudgetPlanEntities
			.Include(bp => bp.DataAccess)
			.ThenInclude(da => da.AccessedPersons.Where(x => x.StatusId == 1))
			.Include(bp => bp.TransactionCategories.Where(tc => tc.StatusId == 1))
			.ThenInclude(tc => tc.SubTransactionCategories.Where(stc => stc.StatusId == 1))
			.ThenInclude(stc => stc.TransactionDetails.Where(td => td.StatusId == 1))
			.Include(bp => bp.BudgetPlanBases.Where(x => x.StatusId == 1))
			.ThenInclude(bpb => bpb.BudgetPlanDetailsList.Where(bpd => bpd.StatusId == 1))
			.Where(bp => bp.Id == id && bp.StatusId == 1)
			.FirstOrDefaultAsync(cancellationToken);

		if (budgetPlan == null)
			throw new NotFoundException(nameof(BudgetPlanEntity), id);

		if (!budgetPlan.DataAccess.IsAccessed(currentUserService.Email))
			throw new AccessDeniedException();

		return budgetPlan;
	}
	
	public async Task<BudgetPlanEntity> GetByIdWithTransactionDetailsAndTransactionCategoriesAsync(Guid id, CancellationToken cancellationToken = default)
	{
		if (id.IsNullOrEmpty())
			throw new ArgumentException("Id is null or empty", nameof(id));

		var budgetPlan = await ctx.BudgetPlanEntities
			.Where(x => x.Id == id)
			.Include(x => x.DataAccess)
			.ThenInclude(x => x.AccessedPersons.Where(x => x.StatusId == 1))
			.Include(x => x.TransactionCategories.Where(x => x.OverTransactionCategoryId == null && x.StatusId == 1))
			.ThenInclude(x => x.SubTransactionCategories.Where(x => x.StatusId == 1))
			.ThenInclude(x => x.TransactionDetails.Where(x => x.StatusId == 1))
			.FirstOrDefaultAsync(cancellationToken);

		if (budgetPlan == null)
			throw new NotFoundException(nameof(BudgetPlanEntity), id);

		if (!budgetPlan.DataAccess.IsAccessed(currentUserService.Email))
			throw new AccessDeniedException();

		return budgetPlan;
	}

	public async Task<List<BudgetPlanEntity>> GetBudgetPlansForCurrentUserAsync(
		CancellationToken cancellationToken = default)
	{
		return await ctx.BudgetPlanEntities
			.Include(x => x.DataAccess)
			.ThenInclude(x => x.AccessedPersons)
			.Where(x => x.DataAccess.AccessedPersons.Any(x => x.Email == currentUserService.Email))
			.ToListAsync(cancellationToken);
	}
}