
using BudgetPlan.Domain.Enums;

namespace BudgetPlan.Shared.Dtos;

public class BudgetPlanDetailsViewDto
{
	public Guid Id { get;set; }
	public double AmountAllocated { get; set;} = 0f;
	public double SumAmountOfAllDay => TransactionItemsForDaysDtos.Sum(x => x.SumAmountOfTheDay);
	public TransactionType? TransactionType { get; set; }
	public double Difference => TransactionType == Domain.Enums.TransactionType.Expense ? AmountAllocated - SumAmountOfAllDay : SumAmountOfAllDay - AmountAllocated;
	public List<TransactionItemsPerDayDto> TransactionItemsForDaysDtos { get; set; } = new();
}