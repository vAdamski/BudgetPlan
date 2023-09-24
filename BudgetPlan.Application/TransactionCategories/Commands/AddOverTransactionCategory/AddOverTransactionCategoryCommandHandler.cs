using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlan.Application.TransactionCategories.Commands.AddOverTransactionCategory;

public class AddOverTransactionCategoryCommandHandler : IRequestHandler<AddOverTransactionCategoryCommand, Guid>
{
    private readonly IBudgetPlanDbContext _ctx;
    private readonly ICurrentUserService _currentUserService;

    public AddOverTransactionCategoryCommandHandler(IBudgetPlanDbContext ctx, ICurrentUserService currentUserService)
    {
        _ctx = ctx;
        _currentUserService = currentUserService;
    }

    public async Task<Guid> Handle(AddOverTransactionCategoryCommand request, CancellationToken cancellationToken)
    {
        TransactionCategory transactionCategory = new TransactionCategory()
        {
            TransactionCategoryName = request.TransactionCategoryName,
            TransactionType = request.TransactionType,
            OverTransactionCategoryId = null
        };

        await _ctx.TransactionCategories.AddAsync(transactionCategory, cancellationToken);
        await _ctx.SaveChangesAsync(cancellationToken);

        return transactionCategory.Id;
    }
}