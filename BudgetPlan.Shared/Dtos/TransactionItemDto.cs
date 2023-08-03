namespace BudgetPlan.Shared.Dtos;

public class TransactionItemDto
{
    public int Id { get; set; }
    public float Value { get; set; }
    public string Description { get; set; } = "";
    public DateTime TransactionDate { get; set; }
}