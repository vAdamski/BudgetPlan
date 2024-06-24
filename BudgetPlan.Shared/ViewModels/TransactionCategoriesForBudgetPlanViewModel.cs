using BudgetPlan.Domain.Entities;
using BudgetPlan.Shared.Dtos;

namespace BudgetPlan.Shared.ViewModels;

public class TransactionCategoriesForBudgetPlanViewModel
{
	public List<OverTransactionCategoryDto> TransactionCategoryDtos { get; set; } = new();

	public TransactionCategoriesForBudgetPlanViewModel(List<TransactionCategory> transactionCategories)
	{
		TransactionCategoryDtos = transactionCategories
			.Select(tc => new OverTransactionCategoryDto(tc, tc.SubTransactionCategories.ToList()))
			.ToList();
	}
}