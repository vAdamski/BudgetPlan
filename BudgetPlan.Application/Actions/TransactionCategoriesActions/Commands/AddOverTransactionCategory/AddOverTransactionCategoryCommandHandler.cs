using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Domain.Entities;
using MediatR;

namespace BudgetPlan.Application.Actions.TransactionCategoriesActions.Commands.AddOverTransactionCategory;

public class AddOverTransactionCategoryCommandHandler : IRequestHandler<AddOverTransactionCategoryCommand, Guid>
{
    private readonly IBudgetPlanDbContext _ctx;

    public AddOverTransactionCategoryCommandHandler(IBudgetPlanDbContext ctx)
    {
        _ctx = ctx;
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