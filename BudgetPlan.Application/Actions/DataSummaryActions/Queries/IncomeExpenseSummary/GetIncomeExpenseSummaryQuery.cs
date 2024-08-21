namespace BudgetPlan.Application.Actions.DataSummaryActions.Queries.IncomeExpenseSummary;

public class GetIncomeExpenseSummaryQuery(Guid budgetPlanId, Guid? budgetPlanBaseId = null, bool percent = false)
{
	public Guid BudgetPlanId { get; } = budgetPlanId;
	public Guid? BudgetPlanBaseId { get; } = budgetPlanBaseId;
	public bool Percent { get; } = percent;
}