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

    public async Task<BudgetPlanEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        if (id.IsNullOrEmpty())
            throw new ArgumentException("Id is null or empty", nameof(id));

        var budgetPlan = await ctx.BudgetPlanEntities
            .Where(x => x.Id == id)
            .Include(x => x.DataAccess)
            .ThenInclude(x => x.AccessedPersons)
            .Include(x => x.TransactionCategories)
            .ThenInclude(x => x.SubTransactionCategories)
            .Include(x => x.BudgetPlanBases)
            .ThenInclude(x => x.BudgetPlanDetailsList)
            .FirstOrDefaultAsync(cancellationToken);

        if (budgetPlan == null)
            throw new BudgetPlanNotFoundException(id);
        
        if (!budgetPlan.DataAccess.IsAccessed(currentUserService.Email))
            throw new AccessDeniedException();

        return budgetPlan;
    }

    public async Task<List<BudgetPlanEntity>> GetBudgetPlans(CancellationToken cancellationToken = default)
    {
        return await ctx.BudgetPlanEntities
            .Include(x => x.DataAccess)
            .ThenInclude(x => x.AccessedPersons)
            .Where(x => x.DataAccess.AccessedPersons.Any(x => x.Email == currentUserService.Email))
            .ToListAsync(cancellationToken);
    }
}