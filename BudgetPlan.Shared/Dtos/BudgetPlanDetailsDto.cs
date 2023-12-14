namespace BudgetPlan.Shared.Dtos;

public class BudgetPlanDetailsDto
{
    public BudgetPlanDetailsDto(Guid id, List<TransactionItemsForDayDto> transactionItemsForDaysDtos, double amountAllocated)
    {
        Id = id;
        AmountAllocated = amountAllocated;
        TransactionItemsForDaysDtos = transactionItemsForDaysDtos;
    }

    public Guid Id { get; }
    public double AmountAllocated { get; } = 0f;
    public double ValueOfTransactionItemsForDays => TransactionItemsForDaysDtos.Sum(x => x.ValuesOfTransactionItemsForDay);
    public List<TransactionItemsForDayDto> TransactionItemsForDaysDtos { get; }
}