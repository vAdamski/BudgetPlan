using BudgetPlan.Application.Common.Interfaces.Managers;
using BudgetPlan.Shared.ViewModels;
using MediatR;

namespace BudgetPlan.Application.Actions.DataAccessActions.Queries.GetListOfAccesses;

public class GetListOfAccessesQueryHandler(IDataAccessManager dataAccessManager)
	: IRequestHandler<GetListOfAccessesQuery, AccessesListViewModel>
{
	public async Task<AccessesListViewModel> Handle(GetListOfAccessesQuery request, CancellationToken cancellationToken)
	{
		return await dataAccessManager.GetDataAccessesListForCurrentUserAsync(cancellationToken);
	}
}