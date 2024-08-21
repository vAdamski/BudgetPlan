namespace BudgetPlan.Application.Common.Helpers;

public static class PercentTransformer
{
	public static List<double> CalculatePercentsDoubles(List<double> values)
	{
		var total = values.Sum();
		return values.Select(x => x / total * 100).ToList();
	}
}