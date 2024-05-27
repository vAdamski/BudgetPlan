using BudgetPlan.Application.Common.Interfaces.Managers;
using BudgetPlan.Shared.ViewModels;
using MediatR;

namespace BudgetPlan.Application.Actions.DataAccessActions.GetDataAccessForBudgetPlan;

public class GetDataAccessForBudgetPlanQueryHandler(IDataAccessManager dataAccessManager)
	: IRequestHandler<GetDataAccessForBudgetPlanQuery, DataAccessBudgetPlanViewModel>
{
	public async Task<DataAccessBudgetPlanViewModel> Handle(GetDataAccessForBudgetPlanQuery request,
		CancellationToken cancellationToken)
	{
		return await dataAccessManager.GetDataAccessForBudgetPlan(request.Id, cancellationToken);
	}
}