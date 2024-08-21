namespace BudgetPlan.Application.Actions.DataSummaryActions.Queries.IncomeSummary;

public class GetIncomeSummaryQuery(Guid budgetPlanId, Guid? budgetPlanBaseId = null, bool percent = false)
{
	public Guid BudgetPlanId { get; } = budgetPlanId;
	public Guid? BudgetPlanBaseId { get; } = budgetPlanBaseId;
	public bool Percent { get; } = percent;
}