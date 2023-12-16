using BudgetPlan.Shared.Dtos;

namespace BudgetPlan.Application.Common.Interfaces.Services;

public interface IPrepareViewModelTransactionsCategoriesService
{
    Task<List<BudgetPlanOverTransactionCategoryDto>> PrepareViewModelTransactionsCategories(
        CancellationToken cancellationToken = default);
}