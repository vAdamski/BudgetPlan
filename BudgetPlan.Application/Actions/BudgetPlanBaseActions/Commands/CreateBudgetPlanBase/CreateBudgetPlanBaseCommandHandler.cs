using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Domain.Enums;
using BudgetPlan.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlan.Application.Actions.BudgetPlanBaseActions.Commands.CreateBudgetPlanBase;

public class CreateBudgetPlanBaseCommandHandler : IRequestHandler<CreateBudgetPlanBaseCommand, Guid>
{
    private readonly IBudgetPlanDbContext _ctx;
    private readonly ICurrentUserService _currentUserService;

    public CreateBudgetPlanBaseCommandHandler(IBudgetPlanDbContext ctx, ICurrentUserService currentUserService)
    {
        _ctx = ctx;
        _currentUserService = currentUserService;
    }

    public async Task<Guid> Handle(CreateBudgetPlanBaseCommand request, CancellationToken cancellationToken)
    {
        var budgetPlan = await _ctx.BudgetPlanEntities
            .Where(x => x.Id == request.BudgetPlanEntityId)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        
        if (budgetPlan == null)
            throw new NotFoundException(nameof(BudgetPlanEntity), request.BudgetPlanEntityId);
        
        var categories = await _ctx.TransactionCategories
            .Where(x => x.CreatedBy == _currentUserService.Email &&
                        x.OverTransactionCategoryId != null &&
                        x.StatusId == 1)
            .ToListAsync(cancellationToken);
        
        var budgetPlanBase = budgetPlan.AddBudgetPlanBase(request.DateFrom, request.DateTo);
        
        foreach (var category in categories)
        {
            budgetPlanBase.AddBudgetPlanDetail(category.Id);
        }
        
        await _ctx.SaveChangesAsync(cancellationToken);
        
        return budgetPlanBase.Id;
    }
}