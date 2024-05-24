using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Shared.Dtos;

public class BudgetPlanDto
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	
	public BudgetPlanDto(BudgetPlanEntity budgetPlanEntity)
	{
		Id = budgetPlanEntity.Id;
		Name = budgetPlanEntity.Name;
	}
}