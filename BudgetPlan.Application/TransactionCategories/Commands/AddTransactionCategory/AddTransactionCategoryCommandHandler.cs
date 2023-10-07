using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Domain.Enums;
using BudgetPlan.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BudgetPlan.Application.TransactionCategories.Commands.AddTransactionCategory;

public class AddTransactionCategoryCommandHandler : IRequestHandler<AddTransactionCategoryCommand, Guid>
{
    private readonly IBudgetPlanDbContext _ctx;
    private readonly ICurrentUserService _currentUserService;

    public AddTransactionCategoryCommandHandler(IBudgetPlanDbContext ctx, ICurrentUserService currentUserService)
    {
        _ctx = ctx;
        _currentUserService = currentUserService;
    }

    public async Task<Guid> Handle(AddTransactionCategoryCommand request, CancellationToken cancellationToken)
    {
        TransactionCategory transactionCategory = new TransactionCategory()
        {
            TransactionCategoryName = request.TransactionCategoryName
        };

        var overTransactionCategory = await _ctx.TransactionCategories
            .Where(x => x.Id == request.OverTransactionCategoryId &&
                        x.CreatedBy == _currentUserService.Email &&
                        x.StatusId == 1)
            .FirstOrDefaultAsync(cancellationToken);

        if (overTransactionCategory is null)
            throw new OverTransactionCategoryNotFoundException(request.OverTransactionCategoryId);

        transactionCategory.OverTransactionCategoryId = overTransactionCategory.Id;
        transactionCategory.TransactionType = overTransactionCategory.TransactionType;
        
        await _ctx.TransactionCategories.AddAsync(transactionCategory, cancellationToken);
        await _ctx.SaveChangesAsync(cancellationToken);

        if (transactionCategory.OverTransactionCategoryId != null)
        {
            var budgetPlans = await _ctx.BudgetPlanBases
                .Where(x => x.CreatedBy == _currentUserService.Email &&
                            x.StatusId == 1)
                .ToListAsync(cancellationToken);

            foreach (var budgetPlan in budgetPlans)
            {
                var budgetPlanDetails = new BudgetPlanDetails
                {
                    ExpectedAmount = 0,
                    BudgetPlanType = BudgetPlanType.Monthly,
                    BudgetPlanBaseId = budgetPlan.Id,
                    TransactionCategoryId = transactionCategory.Id
                };

                await _ctx.BudgetPlanDetails.AddAsync(budgetPlanDetails, cancellationToken);
            }

            await _ctx.SaveChangesAsync(cancellationToken);
        }

        return transactionCategory.Id;
    }
}