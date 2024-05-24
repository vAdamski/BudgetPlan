using BudgetPlan.Domain.Entities;
using BudgetPlan.Shared.Dtos;

namespace BudgetPlan.Shared.ViewModels;

public class TransactionCategoryListViewModel
{
	public List<OverTransactionCategoryDto> OverTransactionCategoryList { get; } = new();

	public TransactionCategoryListViewModel(List<TransactionCategory> transactionCategories)
	{
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