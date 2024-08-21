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
	public async Task<PieChartDataDoubleViewModel> GetExpensesSummary(Guid budgetPlanId, Guid? budgetPlanBaseId,
		bool percents, CancellationToken cancellationToken = default)
	{
		var data = IsBudgetPlanBaseIdGiven(budgetPlanBaseId)
			? await GetDataForBudgetPlanBasePeriod(budgetPlanId, budgetPlanBaseId.Value, cancellationToken)
			: await GetDataForEntirePeriod(budgetPlanId, cancellationToken);

		var labels = new List<string>() { "Planoweane wydatki", "Rzeczywiste wydatki" };
		
		var expectedExpenses =  data.BudgetPlanBases
			.SelectMany(x => x.BudgetPlanDetailsList)
			.Where(x => x.StatusId == 1 && x.TransactionCategory.TransactionType == TransactionType.Expense && x.TransactionCategory.StatusId == 1)
			.Sum(x => x.ExpectedAmount);
		
		var realExpenses = data.BudgetPlanBases
			.SelectMany(x => x.BudgetPlanDetailsList)
			.Where(x => x.StatusId == 1 && x.TransactionCategory.TransactionType == TransactionType.Expense && x.TransactionCategory.StatusId == 1)
			.Sum(x => x.TransactionCategory.TransactionDetails.Where(x => x.StatusId == 1).Sum(y => y.Value));
		
		var values = new List<double>() { expectedExpenses, realExpenses };
		
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
			.Where(x => x.Id == budgetPlanId &&
			            x.StatusId == 1)
			.FirstOrDefaultAsync(cancellationToken);

		if (budgetPlan == null)
			throw new NotFoundException(nameof(BudgetPlanEntity), budgetPlanId);

		return budgetPlan;
	}

	public async Task<BudgetPlanEntity> GetDataForBudgetPlanBasePeriod(Guid budgetPlanId, Guid budgetPlanBaseId,
		CancellationToken cancellationToken = default)
	{
		var budgetPlan = await ctx.BudgetPlanEntities
			.Include(x => x.TransactionCategories)
			.ThenInclude(x => x.TransactionDetails)
			.Include(x => x.BudgetPlanBases)
			.ThenInclude(x => x.BudgetPlanDetailsList)
			.Where(x => x.Id == budgetPlanId &&
			            x.StatusId == 1 &&
			            x.BudgetPlanBases.Any(x => x.Id == budgetPlanBaseId))
			.FirstOrDefaultAsync(cancellationToken);

		if (budgetPlan == null)
			if (budgetPlan == null)
				throw new NotFoundException(nameof(BudgetPlanEntity), budgetPlanId);

		return budgetPlan;
	}

	private bool IsBudgetPlanBaseIdGiven(Guid? budgetPlanBaseId)
	{
		return budgetPlanBaseId.HasValue;
	}
}