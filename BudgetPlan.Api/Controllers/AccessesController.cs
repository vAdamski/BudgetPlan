using BudgetPlan.Application.Actions.DataAccessActions.Commands.AddUserToAccess;
using BudgetPlan.Application.Actions.DataAccessActions.Commands.RemoveUserFromAccess;
using BudgetPlan.Application.Actions.DataAccessActions.Commands.UpdateDataAccessForBudgetPlan;
using BudgetPlan.Application.Actions.DataAccessActions.Queries.GetListOfAccesses;
using BudgetPlan.Shared.Dtos;
using BudgetPlan.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlan.Api.Controllers;

[Route("api/[controller]")]
public class AccessesController : BaseController
{
	[HttpGet]
	public async Task<IActionResult> GetAccessesList()
	{
		var response = await Mediator.Send(new GetListOfAccessesQuery());
		
		return Ok(response);
	}
	
	[HttpPost]
	[Route("{id}/users")]
	public async Task<IActionResult> AddUserToAccess(Guid id,AddUserToAccessDto addUserToAccessDto)
	{
		await Mediator.Send(new AddUserToAccessCommand(id, addUserToAccessDto));
		
		return NoContent();
	}
	
	[HttpDelete]
	[Route("{id/users}")]
	public async Task<IActionResult> RemoveUserFromAccess(Guid id, RemoveUserFromAccessDto removeUserFromAccessDto)
	{
		await Mediator.Send(new RemoveUserFromAccessCommand(id, removeUserFromAccessDto));
		
		return NoContent();
	}

	[HttpPut]
	[Route("{id}")]
	public async Task<IActionResult> UpdateAccess(Guid id, UpdateDataAccessViewModel updateDataAccessViewModel)
	{
		if (id != updateDataAccessViewModel.AccessId)
			return BadRequest();

		await Mediator.Send(new UpdateDataAccessForBudgetPlanCommand(id, updateDataAccessViewModel));
		
		return NoContent();
	}
}