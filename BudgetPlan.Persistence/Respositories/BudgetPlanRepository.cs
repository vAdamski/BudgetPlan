using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Application.Common.Interfaces.Repositories;
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
    
    public async Task<List<Domain.Entities.BudgetPlan>>  GetBudgetPlansForCurrentUser()
    {
        return await _context.BudgetPlans
            .Where(x => x.CreatedBy == _currentUserService.Email &&
                        x.StatusId == 1)
            .ToListAsync();
    }
}