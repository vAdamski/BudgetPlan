namespace BudgetPlan.Shared.Dtos;

public class AddTransactionDetailDto
{
	public double Value { get; set; }
	public string Description { get; set; }
	public Guid TransactionCategoryId { get; set; }
	public DateOnly TransactionDate { get; set; }
}