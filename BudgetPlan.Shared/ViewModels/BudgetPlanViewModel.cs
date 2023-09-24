using BudgetPlan.Shared.Dtos;
using BudgetPlan.Shared.Enums;

namespace BudgetPlan.Shared.ViewModels;

public class BudgetPlanViewModel
{
    public double Balance => Income - Expenses;
    public double Income => BudgetPlanOverTransactionCategoryDtos.Where(x => x.TransactionType == TransactionType.Income)
        .Sum(x => x.SumOfAllCategories);
    public double Expenses => BudgetPlanOverTransactionCategoryDtos.Where(x => x.TransactionType == TransactionType.Expense)
        .Sum(x => x.SumOfAllCategories);

    public List<BudgetPlanOverTransactionCategoryDto> BudgetPlanOverTransactionCategoryDtos { get; set; } = new();
}