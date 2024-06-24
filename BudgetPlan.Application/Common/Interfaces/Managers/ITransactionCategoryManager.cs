using BudgetPlan.Shared.ViewModels;

namespace BudgetPlan.Application.Common.Interfaces.Managers;

public interface ITransactionCategoryManager
{
	Task<Guid> AddTransactionCategoryAsync(Guid overTransactionCategoryId,
		string categoryName, CancellationToken cancellationToken = default);

	Task<SubTransactionCategoriesViewModel> GetSubTransactionCategoriesForBudgetPlan(Guid requestBudgetPlanId, CancellationToken cancellationToken = default);
	Task<TransactionCategoriesForBudgetPlanViewModel> GetTransactionCategoriesForBudgetPlan(Guid requestBudgetPlanId, CancellationToken cancellationToken = default);
}