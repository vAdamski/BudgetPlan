using BudgetPlan.Application.Common.Interfaces.Managers;
using MediatR;

namespace BudgetPlan.Application.Actions.TransactionDetailsActions.Commands.DeleteTransactionDetail;

public class DeleteTransactionDetailCommandHandler(ITransactionDetailsManager transactionDetailsManager) : IRequestHandler<DeleteTransactionDetailCommand>
{
	public async Task Handle(DeleteTransactionDetailCommand request, CancellationToken cancellationToken)
	{
		await transactionDetailsManager.DeleteAsync(request.Id, cancellationToken);
	}
}