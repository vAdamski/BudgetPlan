using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Domain.Enums;
using BudgetPlan.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlan.Application.Actions.BudgetPlanBaseActions.Commands.CreateBudgetPlanBase;

public class CreateBudgetPlanBaseCommandHandler(IBudgetPlanDbContext ctx, ICurrentUserService currentUserService)
	: IRequestHandler<CreateBudgetPlanBaseCommand, Guid>
{
	public async Task<Guid> Handle(CreateBudgetPlanBaseCommand request, CancellationToken cancellationToken)
	{
		var budgetPlan = await ctx.BudgetPlanEntities
			.Include(x => x.DataAccess)
			.ThenInclude(x => x.AccessedPersons)
			.Include(x => x.TransactionCategories)
			.ThenInclude(x => x.SubTransactionCategories)
			.FirstOrDefaultAsync(x => x.Id == request.BudgetPlanEntityId &&
			                          x.DataAccess.AccessedPersons.Any(x => x.Email == currentUserService.Email),
				cancellationToken);

		if (budgetPlan == null)
			throw new NotFoundException(nameof(BudgetPlanEntity), request.BudgetPlanEntityId);

		var budgetPlanBase = budgetPlan.AddBudgetPlanBase(request.DateFrom, request.DateTo);

		await ctx.SaveChangesAsync(cancellationToken);

		return budgetPlanBase.Id;
	}
}