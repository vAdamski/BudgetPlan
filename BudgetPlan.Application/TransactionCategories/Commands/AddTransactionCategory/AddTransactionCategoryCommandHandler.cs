using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BudgetPlan.Application.TransactionCategories.Commands.AddTransactionCategory;

public class AddTransactionCategoryCommandHandler : IRequestHandler<AddTransactionCategoryCommand, int>
{
    private readonly IBudgetPlanDbContext _ctx;
    private readonly ICurrentUserService _currentUserService;
    private readonly ILogger<AddTransactionCategoryCommandHandler> _logger;

    public AddTransactionCategoryCommandHandler(IBudgetPlanDbContext ctx, ICurrentUserService currentUserService,
        ILogger<AddTransactionCategoryCommandHandler> logger)
    {
        _ctx = ctx;
        _currentUserService = currentUserService;
        _logger = logger;
    }

    public async Task<int> Handle(AddTransactionCategoryCommand request, CancellationToken cancellationToken)
    {
        TransactionCategory transactionCategory = new TransactionCategory()
        {
            TransactionCategoryName = request.TransactionCategoryName
        };

        try
        {
            var overTransactionCategory = await _ctx.TransactionCategories
                .Where(x => x.Id == request.OverTransactionCategoryId &&
                            x.CreatedBy == _currentUserService.Email &&
                            x.StatusId == 1)
                .FirstOrDefaultAsync(cancellationToken);

            if (overTransactionCategory == null)
            {
                throw new OverTransactionCategoryNotFoundException(overTransactionCategory.Id);
            }

            transactionCategory.OverTransactionCategoryId = overTransactionCategory.Id;
            transactionCategory.TransactionType = overTransactionCategory.TransactionType;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while adding transaction category");
            throw;
        }

        await _ctx.TransactionCategories.AddAsync(transactionCategory, cancellationToken);
        await _ctx.SaveChangesAsync(cancellationToken);

        return transactionCategory.Id;
    }
}