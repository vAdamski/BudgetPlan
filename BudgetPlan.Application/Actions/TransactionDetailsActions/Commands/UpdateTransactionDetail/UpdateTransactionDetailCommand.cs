using BudgetPlan.Shared.ViewModels;
using MediatR;

namespace BudgetPlan.Application.Actions.TransactionDetailsActions.Commands.UpdateTransactionDetail;

public class UpdateTransactionDetailCommand : IRequest
{
	public Guid Id { get; }
	public UpdateTransactionDetailsViewModel ViewModel { get; }

	public UpdateTransactionDetailCommand(Guid id, UpdateTransactionDetailsViewModel viewModel)
	{
		Id = id;
		ViewModel = viewModel;
	}
}