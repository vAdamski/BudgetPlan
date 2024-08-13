namespace BudgetPlan.Shared.Dtos;

public class CreateBudgetPlanBaseDto
{
    public DateOnly DateFrom { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public DateOnly DateTo { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public Guid BudgetPlanEntityId { get; set; }
}