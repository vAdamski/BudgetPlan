using BudgetPlan.Application.Common.Interfaces.Managers;
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

public class UpdateDataAccessForBudgetPlanCommandHandler(IDataAccessManager manager) : IRequestHandler<UpdateDataAccessForBudgetPlanCommand>
{
	public async Task Handle(UpdateDataAccessForBudgetPlanCommand request, CancellationToken cancellationToken)
	{
		await manager.UpdateDataAccess(request.Id, request.ViewModel, cancellationToken);
	}
}