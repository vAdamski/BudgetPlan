using BudgetPlan.Application.Common.Interfaces.Managers;
using MediatR;

namespace BudgetPlan.Application.Actions.TransactionDetailsActions.Commands.UpdateTransactionDetail;

public class UpdateTransactionDetailCommandHandler(ITransactionDetailsManager transactionDetailsManager) : IRequestHandler<UpdateTransactionDetailCommand>
{
	public async Task Handle(UpdateTransactionDetailCommand request, CancellationToken cancellationToken)
	{
		await transactionDetailsManager.UpdateAsync(request.Id, request.ViewModel, cancellationToken);
	}
}