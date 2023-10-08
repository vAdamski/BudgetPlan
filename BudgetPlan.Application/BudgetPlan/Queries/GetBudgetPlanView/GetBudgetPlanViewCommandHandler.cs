using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Shared.ViewModels;
using MediatR;

namespace BudgetPlan.Application.BudgetPlan.Queries.GetBudgetPlanView;

public class GetBudgetPlanViewCommandHandler : IRequestHandler<GetBudgetPlanViewCommand, BudgetPlanViewModel>
{
    public GetBudgetPlanViewCommandHandler()
    {
    }

    public async Task<BudgetPlanViewModel> Handle(GetBudgetPlanViewCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}