using BudgetPlan.Shared.Common;

namespace BudgetPlan.Shared.ViewModels;

public class PieChartDataDoubleViewModel : IPieChartData<double>
{
	public PieChartDataDoubleViewModel(List<string> labels, List<double> values)
	{
		if (labels is null)
			throw new ArgumentNullException(nameof(labels));

		if (values is null)
			throw new ArgumentException(nameof(values));

		if (labels.Count != values.Count)
			throw new ArgumentException("Labels and values must have the same length");

		Labels = labels;
		Values = values;
	}

	public List<string> Labels { get; set; } = new();
	public List<double> Values { get; set; } = new();
}