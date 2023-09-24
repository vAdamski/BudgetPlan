using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlan.Persistence.Respositories;

public class BudgetPlanRepository : IBudgetPlanRepository
{
    private readonly IBudgetPlanDbContext _context;
    private readonly ICurrentUserService _currentUserService;

    public BudgetPlanRepository(IBudgetPlanDbContext context, ICurrentUserService currentUserService)
    {
        _context = context;
        _currentUserService = currentUserService;
    }
    
    public async Task<List<BudgetPlanBase>>  GetBudgetPlansForCurrentUser()
    {
        return await _context.BudgetPlanBases
            .Where(x => x.CreatedBy == _currentUserService.Email &&
                        x.StatusId == 1)
            .ToListAsync();
    }
}