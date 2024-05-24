using BudgetPlan.Shared.Dtos;
using MediatR;

namespace BudgetPlan.Application.Actions.BudgetPlanDetailsActions.Commands.UpdateBudgetPlanDetail;

public class UpdateBudgetPlanDetailCommand : IRequest<Unit>
{
	public Guid Id { get; }
	public double ExpectedAmount { get; }
	
	public UpdateBudgetPlanDetailCommand(UpdateBudgetPlanDetailDto dto)
	{
		Id = dto.Id;
		ExpectedAmount = dto.ExpectedAmount;
	}
}