using BudgetPlan.Shared.ViewModels;
using MediatR;

namespace BudgetPlan.Application.Actions.DataAccessActions.Commands.UpdateDataAccessForBudgetPlan;

public class UpdateDataAccessForBudgetPlanCommand : IRequest
{
	public Guid Id { get; }
	public UpdateDataAccessViewModel ViewModel { get; }

	public UpdateDataAccessForBudgetPlanCommand(Guid id, UpdateDataAccessViewModel viewModel)
	{
		Id = id;
		ViewModel = viewModel;
	}
}