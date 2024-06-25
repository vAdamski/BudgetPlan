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
    public async Task<BudgetPlanBase> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var data = await context
            .BudgetPlanBases
            .Include(x => x.DataAccess)
            .ThenInclude(x => x.AccessedPersons)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (data == null)
            throw new NotFoundException(nameof(BudgetPlanBase), id);

        if (!data.DataAccess.IsAccessed(currentUserService.Email))
            throw new AccessDeniedException();

        return data;
    }
    
    public async Task<BudgetPlanBase> GetWithBudgetPlanDetailsByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var data = await context
            .BudgetPlanBases
            .Include(x => x.DataAccess)
            .ThenInclude(x => x.AccessedPersons)
            .Include(x => x.BudgetPlanDetailsList)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (data == null)
            throw new NotFoundException(nameof(BudgetPlanBase), id);

        if (!data.DataAccess.IsAccessed(currentUserService.Email))
            throw new AccessDeniedException();

        return data;
    }
    
    public async Task<List<BudgetPlanBase>> GetAllForUserAsync(CancellationToken cancellationToken = default)
    {
        return await context
            .BudgetPlanBases
            .Include(x => x.DataAccess)
            .ThenInclude(x => x.AccessedPersons)
            .Where(x => x.DataAccess.AccessedPersons.Any(x => x.Email == currentUserService.Email))
            .ToListAsync(cancellationToken);
    }

    public async Task<List<BudgetPlanBase>> GetBudgetPlanBasesForBudgetPlanAsync(Guid requestBudgetPlanId, CancellationToken cancellationToken = default)
    {
        var data = await context
            .BudgetPlanBases
            .Include(x => x.DataAccess)
            .ThenInclude(x => x.AccessedPersons)
            .Where(x => x.StatusId == 1 &&
                        x.BudgetPlanEntityId == requestBudgetPlanId &&
                        x.DataAccess.AccessedPersons.Any(x => x.Email == currentUserService.Email)  )
            .ToListAsync(cancellationToken);
        
        return data;
    }
}