namespace BudgetPlan.Shared.Dtos;

public class TransactionItemsForDayDto
{
    public DateOnly Date { get; set; }
    public double ValuesOfTransactionItemsForDay => TransactionItemDtos.Sum(x => x.Value);
    public List<TransactionItemDto> TransactionItemDtos { get; set; } = new();
}