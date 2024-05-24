using BudgetPlan.Application.Actions.TransactionDetailsActions.Commands.AddTransactionDetail;

namespace BudgetPlan.Application.Common.Interfaces.Managers;

public interface ITransactionDetailsManager
{
	Task<Guid> CreateAsync(AddTransactionDetailCommand request, CancellationToken cancellationToken = default);
}