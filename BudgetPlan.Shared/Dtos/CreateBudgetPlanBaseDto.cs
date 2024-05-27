namespace BudgetPlan.Shared.Dtos;

public class CreateBudgetPlanBaseDto
{
    public DateOnly DateFrom { get; set; }
    public DateOnly DateTo { get; set; }
    public Guid BudgetPlanEntityId { get; set; }
}