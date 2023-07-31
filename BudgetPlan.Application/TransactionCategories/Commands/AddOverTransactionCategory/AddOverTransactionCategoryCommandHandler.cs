using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlan.Application.TransactionCategories.Commands.AddOverTransactionCategory;

public class AddOverTransactionCategoryCommandHandler : IRequestHandler<AddOverTransactionCategoryCommand, int>
{
    private readonly IBudgetPlanDbContext _ctx;
    private readonly ICurrentUserService _currentUserService;

    public AddOverTransactionCategoryCommandHandler(IBudgetPlanDbContext ctx, ICurrentUserService currentUserService)
    {
        _ctx = ctx;
        _currentUserService = currentUserService;
    }

    public async Task<int> Handle(AddOverTransactionCategoryCommand request, CancellationToken cancellationToken)
    {
        TransactionCategory transactionCategory = new TransactionCategory()
        {
            TransactionCategoryName = request.TransactionCategoryName,
            TransactionType = request.TransactionType
        };

        try
        {
            if (request.OverTransactionCategoryId != null)
            {
                var overTransactionCategoryId = await _ctx.TransactionCategories
                    .Where(x => x.OverTransactionCategoryId == request.OverTransactionCategoryId &&
                                x.CreatedBy == _currentUserService.Email &&
                                x.StatusId == 1)
                    .Select(x => x.Id)
                    .FirstOrDefaultAsync(cancellationToken);

                if (overTransactionCategoryId == null)
                {
                    throw new OverTransactionCategoryNotFoundException(overTransactionCategoryId);
                }
            }

            transactionCategory.OverTransactionCategoryId = request.OverTransactionCategoryId;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        await _ctx.TransactionCategories.AddAsync(transactionCategory, cancellationToken);
        await _ctx.SaveChangesAsync(cancellationToken);

        return transactionCategory.Id;
    }
}