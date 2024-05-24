using BudgetPlan.Application.Common.Interfaces.Managers;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Application.Managers;

public class BudgetPlanDetailsManager(IBudgetPlanDetailsRepository budgetPlanDetailsRepository)
	: IBudgetPlanDetailsManager
{
	public async Task Update(Guid id, double expectedAmount, CancellationToken cancellationToken = default)
	{
		BudgetPlanDetails budgetPlanDetails = await budgetPlanDetailsRepository.GetByIdAsync(id, cancellationToken);

		budgetPlanDetails.UpdateExpectedAmount(expectedAmount);

		await budgetPlanDetailsRepository.UpdateAsync(budgetPlanDetails, cancellationToken);
	}
}