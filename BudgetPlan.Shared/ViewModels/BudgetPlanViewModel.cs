using BudgetPlan.Shared.Dtos;
using BudgetPlan.Shared.Enums;

namespace BudgetPlan.Shared.ViewModels;

public class BudgetPlanViewModel
{
    public float Balance => Income - Expenses;
    public float Income => BudgetPlanOverTransactionCategoryDtos.Where(x => x.TransactionType == TransactionType.Income)
        .Sum(x => x.SumOfAllCategories);
    public float Expenses => BudgetPlanOverTransactionCategoryDtos.Where(x => x.TransactionType == TransactionType.Expense)
        .Sum(x => x.SumOfAllCategories);
    public List<BudgetPlanOverTransactionCategoryDto> BudgetPlanOverTransactionCategoryDtos { get; set; }
}