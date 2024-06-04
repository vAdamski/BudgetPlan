using BudgetPlan.Application.Actions.TransactionDetailsActions.Commands.AddTransactionDetail;
using BudgetPlan.Shared.ViewModels;

namespace BudgetPlan.Application.Common.Interfaces.Managers;

public interface ITransactionDetailsManager
{
	Task<Guid> CreateAsync(AddTransactionDetailCommand request, CancellationToken cancellationToken = default);

	Task UpdateAsync(Guid requestId, UpdateTransactionDetailsViewModel requestViewModel,
		CancellationToken cancellationToken = default);

	Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}