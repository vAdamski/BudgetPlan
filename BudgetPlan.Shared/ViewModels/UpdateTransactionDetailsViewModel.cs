namespace BudgetPlan.Shared.ViewModels;

public class UpdateTransactionDetailsViewModel
{
	public Guid Id { get; set; }
	public double Value { get; set; }
	public string Description { get; set; }
	public DateOnly Date { get; set; }
}