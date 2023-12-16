using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BudgetPlan.Application.Actions.TransactionDetailsActions.Commands.AddTransactionDetail;

public class AddTransactionDetailCommandHandler : IRequestHandler<AddTransactionDetailCommand, Guid>
{
    private readonly IBudgetPlanDbContext _ctx;
    private readonly ICurrentUserService _currentUserService;
    private readonly ILogger<AddTransactionDetailCommandHandler> _logger;

    public AddTransactionDetailCommandHandler(IBudgetPlanDbContext ctx, ICurrentUserService currentUserService,
        ILogger<AddTransactionDetailCommandHandler> logger)
    {
        _ctx = ctx;
        _currentUserService = currentUserService;
        _logger = logger;
    }

    public async Task<Guid> Handle(AddTransactionDetailCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var categories = await _ctx.TransactionCategories
                .Where(x => x.CreatedBy == _currentUserService.Email &&
                            x.StatusId == 1 &&
                            x.OverTransactionCategoryId != null)
                .Select(x => x.Id)
                .ToListAsync(cancellationToken);

            if (!categories.Contains(request.TransactionCategoryId))
            {
                throw new TransactionCategoryNotFoundException(request.TransactionCategoryId);
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while adding transaction detail");
            throw;
        }

        var transactionDetail = new TransactionDetail()
        {
            Value = request.Value,
            Description = request.Description,
            TransactionDate = request.TransactionDate != null ? request.TransactionDate : DateTime.Now,
            TransactionCategoryId = request.TransactionCategoryId
        };

        await _ctx.TransactionDetails.AddAsync(transactionDetail, cancellationToken);
        await _ctx.SaveChangesAsync(cancellationToken);

        return transactionDetail.Id;
    }
}