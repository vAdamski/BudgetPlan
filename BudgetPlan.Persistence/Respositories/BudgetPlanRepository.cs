using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Persistence.Respositories;

public class BudgetPlanRepository(IBudgetPlanDbContext ctx, ICurrentUserService currentUserService) : IBudgetPlanRepository
{
    public async Task<BudgetPlanEntity> Create(string name, CancellationToken cancellationToken = default)
    {
        var budgetPlan = BudgetPlanEntity.Create(name, currentUserService.Email);
        
        await ctx.BudgetPlanEntities.AddAsync(budgetPlan, cancellationToken);
        
        await ctx.SaveChangesAsync(cancellationToken);
        
        return budgetPlan;
    }
}