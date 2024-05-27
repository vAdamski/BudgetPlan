using BudgetPlan.Shared.ViewModels;

namespace BudgetPlan.Application.Common.Interfaces.Builders;

public interface IBudgetPlanBaseViewModelBuilder
{
	Task<BudgetPlanBaseViewModel> Create(Guid budgetPlanBaseId, CancellationToken cancellationToken = default);
}