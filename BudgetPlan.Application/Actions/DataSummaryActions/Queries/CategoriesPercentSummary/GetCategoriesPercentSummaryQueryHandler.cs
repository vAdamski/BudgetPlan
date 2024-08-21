using BudgetPlan.Application.Common.Interfaces.Services;
using BudgetPlan.Shared.ViewModels;
using MediatR;

namespace BudgetPlan.Application.Actions.DataSummaryActions.Queries.CategoriesPercentSummary;

public class GetCategoriesPercentSummaryQueryHandler(ITransactionCategoryDataSummaryCollector transactionCategoryDataSummaryCollector)
	: IRequestHandler<GetCategoriesPercentSummaryQuery, PieChartDataDoubleViewModel>
{
	public async Task<PieChartDataDoubleViewModel> Handle(GetCategoriesPercentSummaryQuery request,
		CancellationToken cancellationToken)
	{
		return await transactionCategoryDataSummaryCollector.GetCategoriesPercentSummary(request.BudgetPlanId, request.BudgetPlanBaseId,
			cancellationToken);
	}
}