using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlan.Application.Actions.BudgetPlanActions.Commands.CreateBudgetPlan;

public class CreateBudgetPlanCommandHandler : IRequestHandler<CreateBudgetPlanCommand, Guid>
{
    private readonly IBudgetPlanDbContext _ctx;
    private readonly ICurrentUserService _currentUserService;

    public CreateBudgetPlanCommandHandler(IBudgetPlanDbContext ctx, ICurrentUserService currentUserService)
    {
        _ctx = ctx;
        _currentUserService = currentUserService;
    }

    public async Task<Guid> Handle(CreateBudgetPlanCommand request, CancellationToken cancellationToken)
    {
        var categories = await _ctx.TransactionCategories
            .Where(x => x.CreatedBy == _currentUserService.Email &&
                        x.OverTransactionCategoryId != null &&
                        x.StatusId == 1)
            .ToListAsync(cancellationToken);
        
        var budgetPlan = new BudgetPlanBase(request.Year, request.Month);
        
        await _ctx.BudgetPlanBases.AddAsync(budgetPlan, cancellationToken);
        await _ctx.SaveChangesAsync(cancellationToken);
        
        foreach (var category in categories)
        {
            var budgetPlanDetail = new BudgetPlanDetails
            {
                ExpectedAmount = 0,
                BudgetPlanType = BudgetPlanType.Monthly,
                BudgetPlanBaseId = budgetPlan.Id,
                TransactionCategoryId = category.Id
            };
            
            await _ctx.BudgetPlanDetails.AddAsync(budgetPlanDetail, cancellationToken);
        }
        
        await _ctx.SaveChangesAsync(cancellationToken);
        
        return budgetPlan.Id;
    }
}