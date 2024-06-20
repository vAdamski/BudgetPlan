using BudgetPlan.Domain.Entities;
using BudgetPlan.Shared.Dtos;

namespace BudgetPlan.Shared.ViewModels;

public class TransactionCategoriesForBudgetPlansViewModel
{
	public List<BudgetPlanCategoriesDataDto> BudgetPlanTransactionCategoriesData { get; } = new();

	public TransactionCategoriesForBudgetPlansViewModel(List<BudgetPlanEntity> budgetPlanEntities)
	{
		budgetPlanEntities.ForEach(bpe =>
		{
			var dto = new BudgetPlanCategoriesDataDto(bpe.Id, bpe.Name, bpe.TransactionCategories.ToList());
			BudgetPlanTransactionCategoriesData.Add(dto);
		});
	}
}