using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlan.Application.Actions.TransactionCategoriesActions.Commands.AddOverTransactionCategory;

public class AddOverTransactionCategoryCommandHandler(IBudgetPlanDbContext ctx, ICurrentUserService currentUserService) : IRequestHandler<AddOverTransactionCategoryCommand, Guid>
{
    public async Task<Guid> Handle(AddOverTransactionCategoryCommand request, CancellationToken cancellationToken)
    {
        var budgetPlan = await ctx.BudgetPlanEntities
            .Where(x => x.Id == request.BudgetPlanId)
            .Include(x => x.DataAccess)
            .Include(x => x.TransactionCategories)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        
        if (budgetPlan == null)
            throw new BudgetPlanNotFoundException(request.BudgetPlanId);
        
        if (budgetPlan.DataAccess.IsAccessed(currentUserService.Email))
            throw new AccessDeniedException();
        
        budgetPlan.AddOverTransactionCategory(request.Name, request.TransactionType);
        
        await ctx.SaveChangesAsync(cancellationToken);
        
        return budgetPlan.Id;
    }
}