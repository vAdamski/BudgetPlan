namespace BudgetPlan.Shared.Dtos;

public class BudgetPlanDetailsDto
{
    public float AmountAllocated { get; set; } = 0f;
    public float ValueOfTransactionItemsForDays =>
        TransactionItemsForDaysDtos.Sum(x => x.ValuesOfTransactionItemsForDay);
    public List<TransactionItemsForDayDto> TransactionItemsForDaysDtos { get; set; } = new();
}