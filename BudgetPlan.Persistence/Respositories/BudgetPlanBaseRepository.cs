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
    public async Task<List<BudgetPlanBase>> GetAllForUserAsync(CancellationToken cancellationToken = default)
    {
        return await context
            .BudgetPlanBases
            .Include(x => x.DataAccess)
            .ThenInclude(x => x.AccessedPersons)
            .Where(x => x.DataAccess.AccessedPersons.Any(x => x.Email == currentUserService.Email))
            .ToListAsync(cancellationToken);
    }
}