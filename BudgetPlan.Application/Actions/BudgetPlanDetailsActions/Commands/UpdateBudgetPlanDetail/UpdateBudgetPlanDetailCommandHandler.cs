using BudgetPlan.Application.Common.Interfaces.Managers;
using MediatR;

namespace BudgetPlan.Application.Actions.BudgetPlanDetailsActions.Commands.UpdateBudgetPlanDetail;

public class UpdateBudgetPlanDetailCommandHandler(IBudgetPlanDetailsManager manager) : IRequestHandler<UpdateBudgetPlanDetailCommand, Unit>
{
	public async Task<Unit> Handle(UpdateBudgetPlanDetailCommand request, CancellationToken cancellationToken)
	{
		await manager.Update(request.Id, request.ExpectedAmount, cancellationToken);
		
		return Unit.Value;
	}
}