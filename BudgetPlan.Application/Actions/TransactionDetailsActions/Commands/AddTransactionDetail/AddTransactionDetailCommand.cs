using BudgetPlan.Domain.Entities;
using BudgetPlan.Shared.Dtos;
using MediatR;

namespace BudgetPlan.Application.Actions.TransactionDetailsActions.Commands.AddTransactionDetail;

public class AddTransactionDetailCommand : IRequest<Guid>
{
	public double Value { get; }
	public string Description { get; }
	public Guid TransactionCategoryId { get; }
	public DateOnly TransactionDate { get; }

	public AddTransactionDetailCommand(AddTransactionDetailDto transactionDetailDto)
	{
		TransactionCategoryId = transactionDetailDto.TransactionCategoryId;
		Value = transactionDetailDto.Value;
		Description = transactionDetailDto.Description;
		TransactionDate = transactionDetailDto.TransactionDate;
	}
}