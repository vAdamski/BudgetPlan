using BudgetPlan.Shared.ViewModels;

namespace BudgetPlan.Application.Common.Interfaces;

public interface IBudgetPlanVmCreatorService
{
    Task<BudgetPlanViewModel> Create(Guid budgetPlanId);
}