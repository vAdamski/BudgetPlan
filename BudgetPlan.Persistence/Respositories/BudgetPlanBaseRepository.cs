using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Common.Extension;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlan.Persistence.Respositories;

public class BudgetPlanBaseRepository : IBudgetPlanBaseRepository
{
    private readonly IBudgetPlanDbContext _context;
    private readonly ICurrentUserService _currentUserService;

    public BudgetPlanBaseRepository(IBudgetPlanDbContext context, ICurrentUserService currentUserService)
    {
        _context = context;
        _currentUserService = currentUserService;
    }

    public async Task<List<BudgetPlanBase>> GetBudgetPlansForCurrentUser(CancellationToken cancellationToken = default)
    {
        return await _context.BudgetPlanBases
            .Where(x => x.Access.AccessedPersons.Any(x => x.Email == _currentUserService.Email))
            .IsActive()
            .ToListAsync(cancellationToken);
    }

    public async Task<List<BudgetPlanBase>> GetBudgetPlansForUser(string userEmail,
        CancellationToken cancellationToken = default)
    {
        if (userEmail == null)
            throw new ArgumentNullException(nameof(userEmail));

        return await _context.BudgetPlanBases
            .Where(x => x.Access.AccessedPersons.Any(x => x.Email == _currentUserService.Email))
            .IsActive()
            .ToListAsync(cancellationToken);
    }

    public async Task<BudgetPlanBase> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        var budgetPlanBase = await _context.BudgetPlanBases
            .Where(x => x.Id == id &&
                        x.Access.AccessedPersons.Any(x => x.Email == _currentUserService.Email))
            .IsActive()
            .FirstOrDefaultAsync(cancellationToken);

        if (budgetPlanBase == null)
            throw new BudgetPlanNotFoundException(id);

        return budgetPlanBase;
    }

    public async Task<BudgetPlanBase> GetByIdWithBudgetPlanDetailsList(Guid id,
        CancellationToken cancellationToken = default)
    {
        var budgetPlanBase = await _context.BudgetPlanBases
            .Where(x => x.Id == id &&
                        x.Access.AccessedPersons.Any(x => x.Email == _currentUserService.Email))
            .IsActive()
            .Include(x => x.BudgetPlanDetailsList)
            .FirstOrDefaultAsync(cancellationToken);

        if (budgetPlanBase == null)
            throw new BudgetPlanNotFoundException(id);

        return budgetPlanBase;
    }

    public async Task<List<BudgetPlanBase>> GetActiveBudgetPlansBasesForCurrentUser(
        CancellationToken cancellationToken = default)
    {
        return await _context.BudgetPlanBases
            .Where(x => x.Access.AccessedPersons.Any(x => x.Email == _currentUserService.Email))
            .IsActive()
            .ToListAsync(cancellationToken);
    }

    public async Task DeleteAsync(BudgetPlanBase budgetPlanBase, CancellationToken cancellationToken = default)
    {
        var budgetPlanDetails = await _context.BudgetPlanDetails
            .Where(x => x.Access.AccessedPersons.Any(x => x.Email == _currentUserService.Email) &&
                        x.BudgetPlanBaseId == budgetPlanBase.Id)
            .IsActive()
            .ToListAsync(cancellationToken);

        _context.BudgetPlanDetails.RemoveRange(budgetPlanDetails);

        _context.BudgetPlanBases.Remove(budgetPlanBase);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var budgetPlanBase = await _context.BudgetPlanBases
            .Where(x => x.Id == id &&
                        x.Access.AccessedPersons.Any(x => x.Email == _currentUserService.Email))
            .IsActive()
            .FirstOrDefaultAsync(cancellationToken);

        if (budgetPlanBase != null)
            await DeleteAsync(budgetPlanBase, cancellationToken);
    }
}