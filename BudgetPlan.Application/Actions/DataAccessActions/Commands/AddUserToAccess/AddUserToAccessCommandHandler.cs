using BudgetPlan.Application.Common.Interfaces.Managers;
using MediatR;

namespace BudgetPlan.Application.Actions.DataAccessActions.Commands.AddUserToAccess;

public class AddUserToAccessCommandHandler(IDataAccessManager dataAccessManager) : IRequestHandler<AddUserToAccessCommand>
{
	public async Task Handle(AddUserToAccessCommand request, CancellationToken cancellationToken)
	{
		await dataAccessManager.AddUserToAccess(request.Id, request.AddUserToAccessDto.UserEmail, cancellationToken);
	}
}