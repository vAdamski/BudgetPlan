using BudgetPlan.Shared.ViewModels;

namespace BudgetPlan.Application.Common.Interfaces.Services;

public interface IBudgetPlanViewModelBuilderService
{
    Task<BudgetPlanViewModel> Build(Guid budgetPlanId, CancellationToken cancellationToken = default);
}