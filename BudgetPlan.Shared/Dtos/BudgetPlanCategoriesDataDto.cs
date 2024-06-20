using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Shared.Dtos;

public class BudgetPlanCategoriesDataDto
{
	public Guid BudgetPlanId { get; }
	public string BudgetPlanName { get; }
	public List<OverTransactionCategoryDto> OverTransactionCategoryList { get; } = new();

	public BudgetPlanCategoriesDataDto(Guid budgetPlanId, string budgetPlanName,
		List<TransactionCategory> transactionCategories)
	{
		BudgetPlanId = budgetPlanId;
		BudgetPlanName = budgetPlanName;
		PopulateOverTransactionCategoryList(transactionCategories);
	}

	private void PopulateOverTransactionCategoryList(List<TransactionCategory> transactionCategories)
	{
		var transactionCategoriesWithoutOverCategory =
			transactionCategories.Where(x => x.OverTransactionCategory == null);

		foreach (var tc in transactionCategoriesWithoutOverCategory)
		{
			var dto = new OverTransactionCategoryDto(tc, tc.SubTransactionCategories.ToList());
			OverTransactionCategoryList.Add(dto);
		}
	}
}