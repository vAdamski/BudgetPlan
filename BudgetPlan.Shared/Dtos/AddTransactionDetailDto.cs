namespace BudgetPlan.Shared.Dtos;

public class AddTransactionDetailDto
{
	public Guid TransactionCategoryId { get; set; }
	public double Value { get; set; }
	public string Description { get; set; } = "";
	public DateOnly TransactionDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
}