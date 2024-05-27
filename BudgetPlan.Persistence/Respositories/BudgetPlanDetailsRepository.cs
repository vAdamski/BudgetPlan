using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlan.Persistence.Respositories;

public class BudgetPlanDetailsRepository(
    IBudgetPlanDbContext context,
    ICurrentUserService currentUserService)
    : IBudgetPlanDetailsRepository
{
    public async Task<BudgetPlanDetails> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var data = await context.BudgetPlanDetails
            .Include(x => x.DataAccess)
            .ThenInclude(x => x.AccessedPersons)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (data == null)
            throw new NotFoundException(nameof(BudgetPlanDetails), id);

        if (!data.DataAccess.IsAccessed(currentUserService.Email))
            throw new AccessDeniedException();

        return data;
    }

    public async Task UpdateAsync(BudgetPlanDetails budgetPlanDetails, CancellationToken cancellationToken = default)
    {
        context.BudgetPlanDetails.Update(budgetPlanDetails);
        await context.SaveChangesAsync(cancellationToken);
    }
}