
using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Shared.Dtos;

public class AccessDetailItemDto
{
	public string Email { get; }

	public AccessDetailItemDto(AccessedPerson accessedPerson)
	{
		Email = accessedPerson.Email;
	}
}