using BudgetPlan.Application.Actions.DataAccessActions.GetListOfAccesses;
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

	[HttpPut]
	[Route("{id}")]
	public async Task<IActionResult> UpdateAccess(Guid id)
	{
		return NoContent();
	}
}