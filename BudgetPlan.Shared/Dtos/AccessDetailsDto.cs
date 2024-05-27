using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Shared.Dtos;

public class AccessDetailsDto
{
	public Guid AccessId { get; }
	public string BudgetPlanName { get; }
	public List<AccessDetailItemDto> AccessedItems { get; } = new();

	public AccessDetailsDto(BudgetPlanEntity budgetPlanEntity)
	{
		if (budgetPlanEntity == null)
			throw new ArgumentException("Cannot be null!", nameof(BudgetPlanEntity));
		
		if (budgetPlanEntity.DataAccess == null)
			throw new ArgumentException("Cannot be null!", nameof(DataAccess));

		if (budgetPlanEntity.DataAccess.AccessedPersons == null || !budgetPlanEntity.DataAccess.AccessedPersons.Any())
			throw new ArgumentException("Cannot be null!", nameof(AccessedPerson));
		
		AccessId = budgetPlanEntity.DataAccessId.Value;
		BudgetPlanName = budgetPlanEntity.Name;
		AccessedItems = budgetPlanEntity.DataAccess.AccessedPersons.Select(x => new AccessDetailItemDto(x)).ToList();
	}
}