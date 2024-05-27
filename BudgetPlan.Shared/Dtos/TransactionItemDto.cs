using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Shared.Dtos;

public class TransactionItemDto
{
	public TransactionItemDto(TransactionDetail transactionDetail)
	{
		Id = transactionDetail.Id;
		Value = transactionDetail.Value;
		Description = transactionDetail.Description;
		Date = transactionDetail.TransactionDate;
	}
	
	public Guid Id { get; set; }
	public double Value { get; set; }
	public string Description { get; set; }
	public DateOnly Date { get; set; }
}