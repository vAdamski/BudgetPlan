using BudgetPlan.Domain.Enums;
using BudgetPlan.Shared.Dtos;

namespace BudgetPlan.Shared.ViewModels;

public class BudgetPlanBaseViewModel
{
	public Guid BudgetPlanBaseId { get; set; }
	public List<TransactionCategoryDetailsViewDto> TransactionCategoryDetailsViewDtos { get; set; } = new();
	
	public double PlannedIncomes => TransactionCategoryDetailsViewDtos
		.Where(x => x.TransactionType == TransactionType.Income)
		.Sum(x => x.PlannedAmount);

	public double RealIncomes => TransactionCategoryDetailsViewDtos
		.Where(x => x.TransactionType == TransactionType.Income)
		.Sum(x => x.RealAmount);

	public double PlannedExpenditure => TransactionCategoryDetailsViewDtos
		.Where(x => x.TransactionType == TransactionType.Expense)
		.Sum(x => x.PlannedAmount);

	public double RealExpenditure => TransactionCategoryDetailsViewDtos
		.Where(x => x.TransactionType == TransactionType.Expense)
		.Sum(x => x.RealAmount);

	public double ExpenditureBalance => PlannedExpenditure - RealExpenditure;
	public double IncomeBalance => PlannedIncomes - RealIncomes;
	public double Balance => IncomeBalance - ExpenditureBalance;
}