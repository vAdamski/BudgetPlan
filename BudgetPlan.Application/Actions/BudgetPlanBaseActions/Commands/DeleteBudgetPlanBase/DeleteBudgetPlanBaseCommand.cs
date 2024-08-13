using MediatR;

namespace BudgetPlan.Application.Actions.BudgetPlanBaseActions.Commands.DeleteBudgetPlanBase;

public class DeleteBudgetPlanBaseCommand(Guid id) : IRequest
{
	public Guid Id { get; } = id;
}