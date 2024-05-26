using BudgetPlan.Domain.Enums;

namespace BudgetPlan.Shared.Dtos;

public class TransactionCategoryDetailsViewDto
{
	public string TransactionCategoryName { get; set; }
	public TransactionType TransactionType { get; set; }
	public List<SubTransactionCategoryDetailsViewDto> SubTransactionCategoryDetailsViewDtos { get; set; } = new();
}