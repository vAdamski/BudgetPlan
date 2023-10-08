using BudgetPlan.Shared.ViewModels;

namespace BudgetPlan.Application.BudgetPlan.Queries.GetBudgetPlanView;

public interface IBudgetPlanViewModelBuilderService
{
    Task<BudgetPlanViewModel> Build(Guid budgetPlanId, CancellationToken cancellationToken = default);
}