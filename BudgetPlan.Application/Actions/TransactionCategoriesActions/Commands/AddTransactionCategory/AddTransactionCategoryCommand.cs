using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlan.Application.Actions.TransactionCategoriesActions.Commands.AddTransactionCategory;

public class AddTransactionCategoryCommand : IRequest<Guid>
{
    public Guid BudgetPlanId { get; }
    public Guid OverTransactionCategoryId { get; }
    public string Name { get; }

    AddTransactionCategoryCommand(Guid budgetPlanId, Guid overTransactionCategoryId, string name)
    {
        BudgetPlanId = budgetPlanId;
        OverTransactionCategoryId = overTransactionCategoryId;
        Name = name;
    }
}

public class AddTransactionCategoryCommandHandler(IBudgetPlanDbContext ctx, ICurrentUserService currentUserService) : IRequestHandler<AddTransactionCategoryCommand, Guid>
{
    public async Task<Guid> Handle(AddTransactionCategoryCommand request, CancellationToken cancellationToken)
    {
        var budgetPlan = await ctx.BudgetPlanEntities
            .Where(x => x.Id == request.BudgetPlanId)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        
        if (budgetPlan == null)
            throw new BudgetPlanNotFoundException(request.BudgetPlanId);
        
        if (budgetPlan.DataAccess.IsAccessed(currentUserService.Email))
            throw new AccessDeniedException();
        
        budgetPlan.AddTransactionCategory(request.OverTransactionCategoryId, request.Name);
        
        await ctx.SaveChangesAsync(cancellationToken);
        
        return budgetPlan.Id;
    }
}