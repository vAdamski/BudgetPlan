using MediatR;

namespace BudgetPlan.Application.Actions.TransactionDetailsActions.Commands.DeleteTransactionDetail;

public class DeleteTransactionDetailCommand : IRequest
{
	public Guid Id { get; }

	public DeleteTransactionDetailCommand(Guid id)
	{
		Id = id;
	}
}