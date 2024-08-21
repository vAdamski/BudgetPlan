using BudgetPlan.Application.Common.Helpers;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Application.Common.Interfaces.Services;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Domain.Enums;
using BudgetPlan.Shared.ViewModels;

namespace BudgetPlan.Application.Services;

public class TransactionCategoryTransactionCategoryDataSummaryCollector(
	IBudgetPlanRepository budgetPlanRepository) : ITransactionCategoryDataSummaryCollector
{
	public async Task<PieChartDataDoubleViewModel> GetCategoriesPercentSummary(Guid budgetPlanId,
		Guid? budgetPlanBaseId, CancellationToken cancellationToken = default)
	{
		return IsBudgetPlanBaseIdGiven(budgetPlanBaseId)
			? await GetSummaryForBudgetPlanBasePeriod(budgetPlanId, budgetPlanBaseId, cancellationToken)
			: await GetSummaryForEntirePeriod(budgetPlanId, cancellationToken);
	}

	private async Task<PieChartDataDoubleViewModel> GetSummaryForBudgetPlanBasePeriod(Guid budgetPlanId,
		Guid? budgetPlanBaseId, CancellationToken cancellationToken = default)
	{
		var data = await budgetPlanRepository.GetBudgetPlanBaseWithDetailsByIdAsync(budgetPlanId, budgetPlanBaseId,
			cancellationToken);
		return CalculateSummary(data);
	}

	private bool IsBudgetPlanBaseIdGiven(Guid? budgetPlanBaseId)
	{
		return budgetPlanBaseId.HasValue;
	}

	private async Task<PieChartDataDoubleViewModel> GetSummaryForEntirePeriod(Guid budgetPlanId,
		CancellationToken cancellationToken = default)
	{
		var data = await budgetPlanRepository.GetByIdAsync(budgetPlanId, cancellationToken);
		return CalculateSummary(data);
	}

	private PieChartDataDoubleViewModel CalculateSummary(BudgetPlanEntity data)
	{
		var labels = new List<string>();
		var values = new List<double>();

		foreach (var mainTransactionCategory in data.TransactionCategories.Where(x => x.TransactionType == TransactionType.Expense && x.IsOverCategory))
		{
			var mainCategoryName = mainTransactionCategory.TransactionCategoryName;
			var mainCategoryValue =
				mainTransactionCategory.SubTransactionCategories.Sum(x => x.TransactionDetails.Sum(y => y.Value));

			labels.Add(mainCategoryName);
			values.Add(mainCategoryValue);
		}
		
		var percents = CalculatePercents(values);

		return new PieChartDataDoubleViewModel(labels, percents);
	}
	
	private List<double> CalculatePercents(List<double> values)
	{
		return PercentTransformer.CalculatePercentsDoubles(values);
	}
}