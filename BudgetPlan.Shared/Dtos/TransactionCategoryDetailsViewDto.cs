using BudgetPlan.Domain.Enums;

namespace BudgetPlan.Shared.Dtos;

public class TransactionCategoryDetailsViewDto
{
	public string TransactionCategoryName { get; set; }
	public TransactionType TransactionType { get; set; }
	public List<SubTransactionCategoryDetailsViewDto> SubTransactionCategoryDetailsViewDtos { get; set; } = new();

	public double PlannedAmount => SubTransactionCategoryDetailsViewDtos.Sum(
		x => x.BudgetPlanDetailsDto.AmountAllocated);
	
	public double RealAmount => SubTransactionCategoryDetailsViewDtos.Sum(
		x => x.BudgetPlanDetailsDto.SumAmountOfAllDay);

	public double Difference => TransactionType == Domain.Enums.TransactionType.Expense ? PlannedAmount - RealAmount : RealAmount - PlannedAmount;
}