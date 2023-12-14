namespace BudgetPlan.Shared.Dtos;

public class TransactionItemsForDayDto
{
    public TransactionItemsForDayDto(DateOnly date, List<TransactionItemDto> transactionItemDtos)
    {
        Date = date;
        TransactionItemDtos = transactionItemDtos;
    }
    
    public DateOnly Date { get; }
    public double ValuesOfTransactionItemsForDay => TransactionItemDtos.Sum(x => x.Value);
    public List<TransactionItemDto> TransactionItemDtos { get; } = new();
}