namespace BudgetPlan.Shared.Dtos;

public class CreateBudgetPlanBaseDto
{
    public DateOnly DateFrom { get; }
    public DateOnly DateTo { get; }
    public Guid BudgetPlanEntityId { get; }

    public CreateBudgetPlanBaseDto(DateOnly dateFrom, DateOnly dateTo, Guid budgetPlanEntityId)
    {
        DateFrom = dateFrom;
        DateTo = dateTo;
        BudgetPlanEntityId = budgetPlanEntityId;
    }
}