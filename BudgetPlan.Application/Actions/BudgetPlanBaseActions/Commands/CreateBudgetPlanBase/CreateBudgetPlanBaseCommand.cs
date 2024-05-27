using MediatR;

namespace BudgetPlan.Application.Actions.BudgetPlanBaseActions.Commands.CreateBudgetPlanBase;

public class CreateBudgetPlanBaseCommand : IRequest<Guid>
{
	public DateOnly DateFrom { get; }
	public DateOnly DateTo { get; }
	public Guid BudgetPlanEntityId { get; }

	public CreateBudgetPlanBaseCommand(DateOnly dateFrom, DateOnly dateTo, Guid budgetPlanEntityId)
	{
		DateFrom = dateFrom;
		DateTo = dateTo;
		BudgetPlanEntityId = budgetPlanEntityId;
	}
}