namespace BudgetPlan.Shared.Dtos;

public class BudgetPlanDetailsDto
{
    public BudgetPlanDetailsDto(List<TransactionItemsForDayDto> transactionItemsForDaysDtos, double amountAllocated)
    {
        AmountAllocated = amountAllocated;
        TransactionItemsForDaysDtos = transactionItemsForDaysDtos;
    }
    
    public double AmountAllocated { get; } = 0f;
    public double ValueOfTransactionItemsForDays => TransactionItemsForDaysDtos.Sum(x => x.ValuesOfTransactionItemsForDay);
    public List<TransactionItemsForDayDto> TransactionItemsForDaysDtos { get; }
}