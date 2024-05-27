using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Shared.ViewModels;
using MediatR;

namespace BudgetPlan.Application.Actions.TransactionCategoriesActions.Queries.GetListTransactionCategories;

public class GetListTransactionCategoriesQueryHandler(ITransactionCategoriesRepository transactionCategoriesRepository) : IRequestHandler<GetListTransactionCategoriesQuery, TransactionCategoryListViewModel>
{
	public async Task<TransactionCategoryListViewModel> Handle(GetListTransactionCategoriesQuery request, CancellationToken cancellationToken)
	{
		var transactionCategories = await transactionCategoriesRepository.GetAllTransactionCategories(cancellationToken);
		
		var vm = new TransactionCategoryListViewModel(transactionCategories);

		return vm;
	}
}