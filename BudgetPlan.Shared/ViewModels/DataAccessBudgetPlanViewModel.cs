using BudgetPlan.Domain.Entities;
using BudgetPlan.Shared.Dtos;

namespace BudgetPlan.Shared.ViewModels;

public class DataAccessBudgetPlanViewModel
{
	public Guid AccessId { get; }
	public List<AccessDetailItemDto> AccessedItems { get; } = new();

	public DataAccessBudgetPlanViewModel(BudgetPlanEntity budgetPlanEntity)
	{
		if (budgetPlanEntity == null)
			throw new ArgumentException("Cannot be null!", nameof(BudgetPlanEntity));

		if (budgetPlanEntity.DataAccess == null)
			throw new ArgumentException("Cannot be null!", nameof(DataAccess));

		if (budgetPlanEntity.DataAccess.AccessedPersons == null || !budgetPlanEntity.DataAccess.AccessedPersons.Any())
			throw new ArgumentException("Cannot be null!", nameof(AccessedPerson));

		AccessId = budgetPlanEntity.DataAccessId;
		AccessedItems = budgetPlanEntity.DataAccess.AccessedPersons.Where(x => x.StatusId == 1)
			.Select(x => new AccessDetailItemDto(x)).ToList();
	}
}