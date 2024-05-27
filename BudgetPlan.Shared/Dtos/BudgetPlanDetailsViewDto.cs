
namespace BudgetPlan.Shared.Dtos;

public class BudgetPlanDetailsViewDto
{
	public Guid Id { get;set; }
	public double AmountAllocated { get; set;} = 0f;
	public double SumAmountOfAllDay => TransactionItemsForDaysDtos.Sum(x => x.SumAmountOfTheDay);
	public double Difference => AmountAllocated - SumAmountOfAllDay;
	public List<TransactionItemsPerDayDto> TransactionItemsForDaysDtos { get; set; } = new();
}