using BudgetPlan.Shared.Dtos;

namespace BudgetPlan.Shared.ViewModels;

public class TransactionCategoryListViewModel
{
    public List<OverTransactionCategoryDto> OverTransactionCategoryList { get; set; } = new();
}