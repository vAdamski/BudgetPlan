using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Shared.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlan.Application.Actions.TransactionCategoriesActions.Queries.GetListTransactionCategories;

public class
    GetListTransactionCategoriesQueryHandler : IRequestHandler<GetListTransactionCategoriesQuery,
        TransactionCategoryListViewModel>
{
    private readonly IBudgetPlanDbContext _ctx;
    private readonly ICurrentUserService _currentUserService;
    private readonly ITransactionCategoryListViewModelFactory _transactionCategoryListViewModelFactory;

    public GetListTransactionCategoriesQueryHandler(IBudgetPlanDbContext ctx, ICurrentUserService currentUserService,
        ITransactionCategoryListViewModelFactory transactionCategoryListViewModelFactory)
    {
        _ctx = ctx;
        _currentUserService = currentUserService;
        _transactionCategoryListViewModelFactory = transactionCategoryListViewModelFactory;
    }

    public async Task<TransactionCategoryListViewModel> Handle(GetListTransactionCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        var allTransactionCategories = await _ctx.TransactionCategories
            .Where(x => x.CreatedBy == _currentUserService.Email)
            .ToListAsync(cancellationToken);

        return _transactionCategoryListViewModelFactory.Create(allTransactionCategories);
    }
}