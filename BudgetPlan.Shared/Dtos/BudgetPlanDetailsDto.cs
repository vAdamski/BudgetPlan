namespace BudgetPlan.Shared.Dtos;

public class BudgetPlanDetailsDto
{
    public double AmountAllocated { get; set; } = 0f;
    public double ValueOfTransactionItemsForDays =>
        TransactionItemsForDaysDtos.Sum(x => x.ValuesOfTransactionItemsForDay);
    public List<TransactionItemsForDayDto> TransactionItemsForDaysDtos { get; set; } = new();
}