using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Shared.Dtos;

public class BudgetPlanBaseDto
{
	public Guid Id { get; }
	public DateOnly DateFrom { get; }
	public DateOnly DateTo { get; }

	public BudgetPlanBaseDto(BudgetPlanBase budgetPlanBase)
	{
		Id = budgetPlanBase.Id;
		DateFrom = budgetPlanBase.DateFrom;
		DateTo = budgetPlanBase.DateTo;
	}
}