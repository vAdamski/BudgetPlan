using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlan.Persistence.Respositories;

public class BudgetPlanDetailsRepository : IBudgetPlanDetailsRepository
{
    private readonly IBudgetPlanDbContext _context;
    private readonly ICurrentUserService _currentUserService;

    public BudgetPlanDetailsRepository(IBudgetPlanDbContext context,
        ICurrentUserService currentUserService)
    {
        _context = context;
        _currentUserService = currentUserService;
    }

    public async Task UpdateBudgetPlanDetail(Guid id, double expectedAmount)
    {
        var budgetPlanDetail = await _context.BudgetPlanDetails.FirstOrDefaultAsync(x =>
            x.Id == id &&
            x.BudgetPlanBase.Access.AccessedPersons.Any(y => y.Email == _currentUserService.Email) &&
            x.IsActive);

        if (budgetPlanDetail == null)
        {
            throw new BudgetPlanDetailNotFoundException(id);
        }

        budgetPlanDetail.ExpectedAmount = expectedAmount;

        await _context.SaveChangesAsync();
    }
}