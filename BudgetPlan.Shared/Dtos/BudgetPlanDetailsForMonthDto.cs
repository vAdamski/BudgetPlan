using BudgetPlan.Shared.Enums;

namespace BudgetPlan.Shared.Dtos;

public class BudgetPlanDetailsForMonthDto
{
    public float Value { get; set; } = 0f;
    public string Description { get; set; } = "";
    public BudgetPlanType BudgetPlanType { get; set; }
}