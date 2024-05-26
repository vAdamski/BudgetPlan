namespace BudgetPlan.Shared.Dtos;

public class SubTransactionCategoryDetailsViewDto
{
	public Guid SubCategoryId { get; set; }
	public string SubCategoryName { get; set; }
	public BudgetPlanDetailsViewDto BudgetPlanDetailsDto { get; set; }
}