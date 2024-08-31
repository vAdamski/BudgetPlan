using BudgetPlan.Domain.Entities;
using BudgetPlan.Shared.Dtos;

namespace BudgetPlan.Shared.ViewModels;

public class TransactionCategoriesForBudgetPlanViewModel
{
	public List<OverTransactionCategoryDto> TransactionCategoryDtos { get; set; } = new();

	public TransactionCategoriesForBudgetPlanViewModel(List<TransactionCategory> transactionCategories)
	{
		TransactionCategoryDtos = transactionCategories
			.OrderBy(x => x.TransactionType).ThenBy(x => x.TransactionCategoryName)
			.Select(tc => new OverTransactionCategoryDto(tc, tc.SubTransactionCategories.OrderBy(x => x.TransactionCategoryName).ToList()))
			.ToList();
	}
}