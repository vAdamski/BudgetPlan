using BudgetPlan.Shared.Enums;

namespace BudgetPlan.Shared.Dtos;

public class BudgetPlanOverTransactionCategoryDto
{
    public string OverCategoryName { get; set; }
    public TransactionType TransactionType { get; set; }

    public double SumOfAllCategories =>
        UnderTransactionCategoryDtos.Sum(x => x.BudgetPlanDetailsDto.ValueOfTransactionItemsForDays);

    public List<BudgetPlanUnderTransactionCategoryDto> UnderTransactionCategoryDtos { get; set; }
}