using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Shared.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlan.Application.BudgetPlan.Commands.CreateBudgetPlan;

public class CreateBudgetPlanCommandHandler : IRequestHandler<CreateBudgetPlanCommand, int>
{
    private readonly IBudgetPlanDbContext _ctx;
    private readonly ICurrentUserService _currentUserService;

    public CreateBudgetPlanCommandHandler(IBudgetPlanDbContext ctx, ICurrentUserService currentUserService)
    {
        _ctx = ctx;
        _currentUserService = currentUserService;
    }

    public async Task<int> Handle(CreateBudgetPlanCommand request, CancellationToken cancellationToken)
    {
        var categories = await _ctx.TransactionCategories
            .Where(x => x.CreatedBy == _currentUserService.Email && 
                        x.StatusId == 1)
            .ToListAsync(cancellationToken);
        
        var budgetPlan = new Domain.Entities.BudgetPlan(request.Year, request.Month);
        
        await _ctx.BudgetPlans.AddAsync(budgetPlan, cancellationToken);
        await _ctx.SaveChangesAsync(cancellationToken);
        
        foreach (var category in categories)
        {
            var budgetPlanDetail = new BudgetPlanDetails
            {
                Value = 0,
                BudgetPlanType = BudgetPlanType.Monthly,
                BudgetPlanId = budgetPlan.Id,
                TransactionCategoryId = category.Id
            };
            
            await _ctx.BudgetPlanDetails.AddAsync(budgetPlanDetail, cancellationToken);
        }
        
        await _ctx.SaveChangesAsync(cancellationToken);
        
        return budgetPlan.Id;
    }
}