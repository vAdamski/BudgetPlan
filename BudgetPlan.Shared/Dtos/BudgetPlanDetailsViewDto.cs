
namespace BudgetPlan.Shared.Dtos;

public class BudgetPlanDetailsViewDto
{
	public Guid Id { get;set; }
	public double AmountAllocated { get; set;} = 0f;
	public double ValueOfTransactionItemsForDays => TransactionItemsForDaysDtos.Sum(x => x.ValuesOfTransactionItemsForDay);
	public List<TransactionItemsPerDayDto> TransactionItemsForDaysDtos { get;set; }
}