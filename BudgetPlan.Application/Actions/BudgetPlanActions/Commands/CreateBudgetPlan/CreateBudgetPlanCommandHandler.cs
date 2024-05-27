using BudgetPlan.Application.Common.Interfaces.Repositories;
using MediatR;

namespace BudgetPlan.Application.Actions.BudgetPlanActions.Commands.CreateBudgetPlan;

public class CreateBudgetPlanCommandHandler(IBudgetPlanRepository budgetPlanRepository) : IRequestHandler<CreateBudgetPlanCommand, Guid>
{
    public async Task<Guid> Handle(CreateBudgetPlanCommand request, CancellationToken cancellationToken)
    {
        var budgetPlanEntity = await budgetPlanRepository.Create(request.Name, cancellationToken);
        
        return budgetPlanEntity.Id;
    }
}