using BudgetPlan.Application.Common.Interfaces.Managers;
using MediatR;

namespace BudgetPlan.Application.Actions.DataAccessActions.Commands.UpdateDataAccessForBudgetPlan;

public class UpdateDataAccessForBudgetPlanCommandHandler(IDataAccessManager manager) : IRequestHandler<UpdateDataAccessForBudgetPlanCommand>
{
	public async Task Handle(UpdateDataAccessForBudgetPlanCommand request, CancellationToken cancellationToken)
	{
		await manager.UpdateDataAccess(request.Id, request.ViewModel, cancellationToken);
	}
}