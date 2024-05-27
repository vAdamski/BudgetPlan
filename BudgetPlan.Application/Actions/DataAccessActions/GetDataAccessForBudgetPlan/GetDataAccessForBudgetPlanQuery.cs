using BudgetPlan.Shared.ViewModels;
using MediatR;

namespace BudgetPlan.Application.Actions.DataAccessActions.GetDataAccessForBudgetPlan;

public class GetDataAccessForBudgetPlanQuery : IRequest<DataAccessBudgetPlanViewModel>
{
	public Guid Id { get; }

	public GetDataAccessForBudgetPlanQuery(Guid id)
	{
		Id = id;
	}
}