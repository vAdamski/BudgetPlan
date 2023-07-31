using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlan.Application.TransactionDetails.Commands.AddTransactionDetail;

public class AddTransactionDetailCommandHandler : IRequestHandler<AddTransactionDetailCommand, int>
{
    private readonly IBudgetPlanDbContext _ctx;
    private readonly ICurrentUserService _currentUserService;

    public AddTransactionDetailCommandHandler(IBudgetPlanDbContext ctx, ICurrentUserService currentUserService)
    {
        _ctx = ctx;
        _currentUserService = currentUserService;
    }
    
    public async Task<int> Handle(AddTransactionDetailCommand request, CancellationToken cancellationToken)
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
            Console.WriteLine(e);
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