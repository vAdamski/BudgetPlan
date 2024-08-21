namespace BudgetPlan.Application.Common.Helpers;

public static class PercentTransformer
{
    public static List<double> CalculatePercentsDoubles(List<double> values)
    {
        var total = values.Sum();

        if (total == 0 && values.Count > 0)
        {
            var percentage = 100.0 / values.Count;
            return values.Select(x => percentage).ToList();
        }

        return values.Select(x => x / total * 100).ToList();
    }
}