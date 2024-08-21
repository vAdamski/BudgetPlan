using BudgetPlan.Application.Common.Interfaces.Services;
using BudgetPlan.Shared.ViewModels;
using MediatR;

namespace BudgetPlan.Application.Actions.DataSummaryActions.Queries.ExpenseSummary;

public class GetExpenseSummaryQueryHandler(IIncomesExpenseDataSummaryCollector incomesExpenseDataSummaryCollector) : IRequestHandler<GetExpenseSummaryQuery, PieChartDataDoubleViewModel>
{
	public async Task<PieChartDataDoubleViewModel> Handle(GetExpenseSummaryQuery request, CancellationToken cancellationToken)
	{
		return await incomesExpenseDataSummaryCollector.GetExpensesSummary(request.BudgetPlanId, request.BudgetPlanBaseId, request.Percent, cancellationToken);
	}
}