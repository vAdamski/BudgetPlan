using BudgetPlan.Application.Common.Interfaces.Managers;
using MediatR;

namespace BudgetPlan.Application.Actions.TransactionDetailsActions.Commands.AddTransactionDetail;

public class AddTransactionDetailCommandHandler(ITransactionDetailsManager transactionDetailsManager) : IRequestHandler<AddTransactionDetailCommand, Guid>
{
	public async Task<Guid> Handle(AddTransactionDetailCommand request, CancellationToken cancellationToken)
	{
		return await transactionDetailsManager.CreateAsync(request, cancellationToken);
	}
}