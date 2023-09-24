namespace BudgetPlan.Shared.Dtos;

public class TransactionItemDto
{
    public Guid Id { get; set; }
    public double Value { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
}