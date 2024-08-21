using BudgetPlan.Application.Common.Interfaces.Services;
using MediatR;

namespace BudgetPlan.Application.Actions.DataSummaryActions.Queries.IncomeExpenseSummary;

public class GetIncomeExpenseSummaryQueryHandler(IIncomesExpenseDataSummaryCollector incomesExpenseDataSummaryCollector)
	: IRequestHandler<GetIncomeExpenseSummaryQuery, double>
{
	public async Task<double> Handle(GetIncomeExpenseSummaryQuery request, CancellationToken cancellationToken)
	{
		return await incomesExpenseDataSummaryCollector.LeftToSpend(request.BudgetPlanId, request.BudgetPlanBaseId,
			cancellationToken);
	}
}