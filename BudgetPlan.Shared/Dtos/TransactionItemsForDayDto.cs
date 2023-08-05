namespace BudgetPlan.Shared.Dtos;

public class TransactionItemsForDayDto
{
    public float ValuesOfTransactionItemsForDay => TransactionItemDtos.Sum(x => x.Value);
    public List<TransactionItemDto> TransactionItemDtos { get; set; } = new();
}