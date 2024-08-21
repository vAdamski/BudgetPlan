using BudgetPlan.Application.Common.Helpers;
using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Application.Common.Interfaces.Services;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Domain.Enums;
using BudgetPlan.Domain.Exceptions;
using BudgetPlan.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlan.Application.Services;

public class IncomesExpenseDataSummaryCollector(IBudgetPlanDbContext ctx) : IIncomesExpenseDataSummaryCollector
{
	public async Task<double> LeftToSpend(Guid budgetPlanId, Guid? budgetPlanBaseId, CancellationToken cancellationToken = default)
	{
		var data = await GetDataForEntirePeriod(budgetPlanId, cancellationToken);
		var expectedIncomes = CalculateExpectedAmount(data, budgetPlanBaseId, TransactionType.Income);
		var realIncomes = CalculateRealAmount(data, budgetPlanBaseId, TransactionType.Income);
		var expectedExpenses = CalculateExpectedAmount(data, budgetPlanBaseId, TransactionType.Expense);
		var realExpenses = CalculateRealAmount(data, budgetPlanBaseId, TransactionType.Expense);

		return expectedIncomes - realIncomes - expectedExpenses + realExpenses;
	}
	
	public async Task<PieChartDataDoubleViewModel> GetIncomeSummary(Guid budgetPlanId, Guid? budgetPlanBaseId,
		bool percents, CancellationToken cancellationToken = default)
	{
		var data = await GetDataForEntirePeriod(budgetPlanId, cancellationToken);
		var labels = new List<string> { "Planowane przychody", "Rzeczywiste przychody" };

		var expectedIncomes = CalculateExpectedAmount(data, budgetPlanBaseId, TransactionType.Income);
		var realIncomes = CalculateRealAmount(data, budgetPlanBaseId, TransactionType.Income);

		return CreatePieChartDataViewModel(labels, expectedIncomes, realIncomes, percents);
	}

	public async Task<PieChartDataDoubleViewModel> GetExpensesSummary(Guid budgetPlanId, Guid? budgetPlanBaseId,
		bool percents, CancellationToken cancellationToken = default)
	{
		var data = await GetDataForEntirePeriod(budgetPlanId, cancellationToken);
		var labels = new List<string> { "Planowane wydatki", "Rzeczywiste wydatki" };

		var expectedExpenses = CalculateExpectedAmount(data, budgetPlanBaseId, TransactionType.Expense);
		var realExpenses = CalculateRealAmount(data, budgetPlanBaseId, TransactionType.Expense);

		return CreatePieChartDataViewModel(labels, expectedExpenses, realExpenses, percents);
	}

	private double CalculateExpectedAmount(BudgetPlanEntity data, Guid? budgetPlanBaseId,
		TransactionType transactionType)
	{
		return data.BudgetPlanBases
			.Where(x => !IsBudgetPlanBaseIdGiven(budgetPlanBaseId) || x.Id == budgetPlanBaseId)
			.SelectMany(x => x.BudgetPlanDetailsList)
			.Where(x => x.StatusId == 1 && x.TransactionCategory.TransactionType == transactionType &&
			            x.TransactionCategory.StatusId == 1)
			.Sum(x => x.ExpectedAmount);
	}

	private double CalculateRealAmount(BudgetPlanEntity data, Guid? budgetPlanBaseId, TransactionType transactionType)
	{
		return data.BudgetPlanBases
			.Where(x => !IsBudgetPlanBaseIdGiven(budgetPlanBaseId) || x.Id == budgetPlanBaseId)
			.SelectMany(x => x.BudgetPlanDetailsList)
			.Where(x => x.StatusId == 1 && x.TransactionCategory.TransactionType == transactionType &&
			            x.TransactionCategory.StatusId == 1)
			.Sum(x => x.TransactionCategory.TransactionDetails.Where(x => x.StatusId == 1).Sum(y => y.Value));
	}

	private PieChartDataDoubleViewModel CreatePieChartDataViewModel(List<string> labels, double expectedValue,
		double realValue, bool percents)
	{
		var values = new List<double> { expectedValue, realValue };
		if (percents)
		{
			var percentsValues = PercentTransformer.CalculatePercentsDoubles(values);
			return new PieChartDataDoubleViewModel(labels, percentsValues);
		}

		return new PieChartDataDoubleViewModel(labels, values);
	}

	public async Task<BudgetPlanEntity> GetDataForEntirePeriod(Guid budgetPlanId,
		CancellationToken cancellationToken = default)
	{
		var budgetPlan = await ctx.BudgetPlanEntities
			.Include(x => x.BudgetPlanBases)
			.ThenInclude(x => x.BudgetPlanDetailsList)
			.ThenInclude(x => x.TransactionCategory)
			.ThenInclude(x => x.TransactionDetails)
			.Where(x => x.Id == budgetPlanId && x.StatusId == 1)
			.FirstOrDefaultAsync(cancellationToken);
		if (budgetPlan == null)
			throw new NotFoundException(nameof(BudgetPlanEntity), budgetPlanId);
		return budgetPlan;
	}

	private bool IsBudgetPlanBaseIdGiven(Guid? budgetPlanBaseId) => budgetPlanBaseId.HasValue;
}