using BudgetPlan.Shared.Dtos;
using MediatR;

namespace BudgetPlan.Application.Actions.DataAccessActions.Commands.AddUserToAccess;

public class AddUserToAccessCommand(Guid id, AddUserToAccessDto addUserToAccessDto) : IRequest
{
	public Guid Id { get; } = id;
	public AddUserToAccessDto AddUserToAccessDto { get; } = addUserToAccessDto;
}