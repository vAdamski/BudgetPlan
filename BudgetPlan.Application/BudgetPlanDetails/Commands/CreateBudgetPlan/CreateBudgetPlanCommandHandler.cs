using BudgetPlan.Application.BudgetPlanDetails.Commands.CreateBudgetPlanDetailsForMonthView;
using MediatR;

namespace BudgetPlan.Application.BudgetPlanDetails.Commands.CreateBudgetPlan;

public class CreateBudgetPlanCommandHandler : IRequestHandler<CreateBudgetPlanCommand, int>
{
    public async Task<int> Handle(CreateBudgetPlanCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}