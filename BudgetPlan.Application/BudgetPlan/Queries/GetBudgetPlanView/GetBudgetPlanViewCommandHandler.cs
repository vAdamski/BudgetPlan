using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Shared.ViewModels;
using MediatR;

namespace BudgetPlan.Application.BudgetPlan.Queries.GetBudgetPlanView;

public class GetBudgetPlanViewCommandHandler : IRequestHandler<GetBudgetPlanViewCommand, BudgetPlanViewModel>
{
    private readonly IBudgetPlanDbContext _context;
    private readonly ICurrentUserService _currentUserService;

    public GetBudgetPlanViewCommandHandler(IBudgetPlanDbContext context, ICurrentUserService currentUserService)
    {
        _context = context;
        _currentUserService = currentUserService;
    }

    public async Task<BudgetPlanViewModel> Handle(GetBudgetPlanViewCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}