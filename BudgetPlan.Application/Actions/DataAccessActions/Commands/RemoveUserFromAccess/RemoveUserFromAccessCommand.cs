using BudgetPlan.Shared.Dtos;
using MediatR;

namespace BudgetPlan.Application.Actions.DataAccessActions.Commands.RemoveUserFromAccess;

public class RemoveUserFromAccessCommand(Guid id, RemoveUserFromAccessDto removeUserFromAccessDto) : IRequest
{
	public Guid Id { get; } = id;
	public RemoveUserFromAccessDto RemoveUserFromAccessDto { get; } = removeUserFromAccessDto;
}