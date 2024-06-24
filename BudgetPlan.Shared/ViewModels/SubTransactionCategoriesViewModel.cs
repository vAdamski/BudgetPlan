using BudgetPlan.Shared.Dtos;

namespace BudgetPlan.Shared.ViewModels;

public class SubTransactionCategoriesViewModel
{
	public List<TransactionCategoryDto> SubTransactionCategories { get; set; } = new();
	
	public SubTransactionCategoriesViewModel(List<TransactionCategoryDto> subTransactionCategories)
	{
		SubTransactionCategories = subTransactionCategories;
	}
}