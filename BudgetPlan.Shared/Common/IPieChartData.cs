namespace BudgetPlan.Shared.Common;

public interface IPieChartData<T>
{
	List<string> Labels { get; set; }
	List<T> Values { get; set; }
}