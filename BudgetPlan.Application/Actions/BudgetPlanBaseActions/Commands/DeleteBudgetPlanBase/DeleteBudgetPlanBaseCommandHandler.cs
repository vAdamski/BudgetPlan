using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlan.Application.Actions.BudgetPlanBaseActions.Commands.DeleteBudgetPlanBase;

public class DeleteBudgetPlanBaseCommandHandler(IBudgetPlanDbContext ctx, ICurrentUserService currentUserService)
	: IRequestHandler<DeleteBudgetPlanBaseCommand>
{
	public async Task Handle(DeleteBudgetPlanBaseCommand request, CancellationToken cancellationToken)
	{
		var budgetPlanBase = await ctx.BudgetPlanBases
			.Include(x => x.DataAccess)
			.ThenInclude(x => x.AccessedPersons)
			.Where(x => x.Id == request.Id &&
			            x.StatusId == 1 &&
			            x.DataAccess.AccessedPersons.Any(x => x.Email == currentUserService.Email))
			.FirstOrDefaultAsync(cancellationToken);

		if (budgetPlanBase == null)
			throw new NotFoundException(nameof(BudgetPlanBase), request.Id);

		ctx.BudgetPlanBases.Remove(budgetPlanBase);

		await ctx.SaveChangesAsync(cancellationToken);
	}
}