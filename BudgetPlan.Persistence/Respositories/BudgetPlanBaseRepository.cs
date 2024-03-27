using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Common.Extension;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlan.Persistence.Respositories;

public class BudgetPlanBaseRepository(IBudgetPlanDbContext context, ICurrentUserService currentUserService)
    : IBudgetPlanBaseRepository
{
    public async Task<BudgetPlanBase> Create(Guid budgetPlanId, DateOnly dateFrom, DateOnly dateTo)
    {
        var budgetPlan = await context.BudgetPlanEntities
            .Where(x => x.Id == budgetPlanId && x.Access.AccessedPersons.Any(x => x.Email == currentUserService.Email))
            .IsActive()
            .FirstOrDefaultAsync();
        
        if (budgetPlan == null)
            throw new BudgetPlanNotFoundException(budgetPlanId);
        
        var budgetPlanBase = budgetPlan.AddBudgetPlanBase(dateFrom, dateTo);
        
        await context.SaveChangesAsync();
        
        return budgetPlanBase;
    }
    
    public async Task<List<BudgetPlanBase>> GetBudgetPlansForUser(string userEmail,
        CancellationToken cancellationToken = default)
    {
        if (userEmail == null)
            throw new ArgumentNullException(nameof(userEmail));

        return await context.BudgetPlanBases
            .Where(x => x.Access.AccessedPersons.Any(x => x.Email == userEmail))
            .IsActive()
            .ToListAsync(cancellationToken);
    }

    public async Task<BudgetPlanBase> GetByIdWithBudgetPlanDetailsList(Guid id,
        CancellationToken cancellationToken = default)
    {
        var budgetPlanBase = await context.BudgetPlanBases
            .Where(x => x.Id == id &&
                        x.Access.AccessedPersons.Any(x => x.Email == currentUserService.Email))
            .IsActive()
            .Include(x => x.BudgetPlanDetailsList)
            .FirstOrDefaultAsync(cancellationToken);

        if (budgetPlanBase == null)
            throw new BudgetPlanNotFoundException(id);

        return budgetPlanBase;
    }
}