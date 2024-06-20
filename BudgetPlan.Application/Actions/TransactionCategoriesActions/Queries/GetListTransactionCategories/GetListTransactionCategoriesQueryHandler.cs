using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Shared.Dtos;
using BudgetPlan.Shared.ViewModels;
using MediatR;

namespace BudgetPlan.Application.Actions.TransactionCategoriesActions.Queries.GetListTransactionCategories;

public class GetListTransactionCategoriesQueryHandler(ITransactionCategoriesRepository transactionCategoriesRepository) : IRequestHandler<GetListTransactionCategoriesQuery, TransactionCategoriesForBudgetPlansViewModel>
{
	public async Task<TransactionCategoriesForBudgetPlansViewModel> Handle(GetListTransactionCategoriesQuery request, CancellationToken cancellationToken)
	{
		var budgetPlanEntitiesWithCategories = await transactionCategoriesRepository.GetTransactionCategoriesForBudgetPlansAsync(cancellationToken);
		
		var vm = new TransactionCategoriesForBudgetPlansViewModel(budgetPlanEntitiesWithCategories);

		return vm;
	}
}