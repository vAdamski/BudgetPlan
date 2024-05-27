using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Shared.ViewModels;
using MediatR;

namespace BudgetPlan.Application.Actions.BudgetPlanBaseActions.Queries.GetUserBudgetPlansList;

public class GetUserBudgetPlansListQueryHandler(IBudgetPlanBaseRepository budgetPlanBaseRepository)
	: IRequestHandler<GetUserBudgetPlansListQuery, BudgetPlanBasesListViewModel>
{
	public async Task<BudgetPlanBasesListViewModel> Handle(GetUserBudgetPlansListQuery request,
		CancellationToken cancellationToken)
	{
		var budgetPlanBases = await budgetPlanBaseRepository.GetAllForUserAsync(cancellationToken);

		return new BudgetPlanBasesListViewModel(budgetPlanBases);
	}
}