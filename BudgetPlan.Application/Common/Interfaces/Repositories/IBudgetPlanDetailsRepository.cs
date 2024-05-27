using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Application.Common.Interfaces.Repositories;

public interface IBudgetPlanDetailsRepository
{
	Task<BudgetPlanDetails> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
	Task UpdateAsync(BudgetPlanDetails budgetPlanDetails, CancellationToken cancellationToken = default);
}