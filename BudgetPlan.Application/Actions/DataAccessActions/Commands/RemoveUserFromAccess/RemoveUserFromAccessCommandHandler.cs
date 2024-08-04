using BudgetPlan.Application.Common.Interfaces.Managers;
using MediatR;

namespace BudgetPlan.Application.Actions.DataAccessActions.Commands.RemoveUserFromAccess;

public class RemoveUserFromAccessCommandHandler(IDataAccessManager dataAccessManager) : IRequestHandler<RemoveUserFromAccessCommand>
{
	public async Task Handle(RemoveUserFromAccessCommand request, CancellationToken cancellationToken)
	{
		await dataAccessManager.RemoveUserFromAccess(request.Id, request.RemoveUserFromAccessDto.UserEmail, cancellationToken);
	}
}