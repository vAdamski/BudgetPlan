using BudgetPlan.Application.Common.Interfaces.Services;
using BudgetPlan.Shared.ViewModels;
using MediatR;

namespace BudgetPlan.Application.Actions.DataSummaryActions.Queries.IncomeSummary;

public class GetIncomeSummaryQueryHandler(IIncomesExpenseDataSummaryCollector incomesExpenseDataSummaryCollector)
	: IRequestHandler<GetIncomeSummaryQuery, PieChartDataDoubleViewModel>
{
	public Task<PieChartDataDoubleViewModel> Handle(GetIncomeSummaryQuery request, CancellationToken cancellationToken)
	{
		return incomesExpenseDataSummaryCollector.GetIncomeSummary(request.BudgetPlanId, request.BudgetPlanBaseId,
			request.Percent, cancellationToken);
	}
}