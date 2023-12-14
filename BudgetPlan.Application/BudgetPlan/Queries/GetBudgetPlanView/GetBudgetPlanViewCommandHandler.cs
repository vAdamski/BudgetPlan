using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Shared.ViewModels;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BudgetPlan.Application.BudgetPlan.Queries.GetBudgetPlanView;

public class GetBudgetPlanViewCommandHandler : IRequestHandler<GetBudgetPlanViewCommand, BudgetPlanViewModel>
{
    private readonly IBudgetPlanVmCreatorService _budgetPlanVmCreatorService;
    private readonly ILogger<GetBudgetPlanViewCommandHandler> _logger;

    public GetBudgetPlanViewCommandHandler(IBudgetPlanVmCreatorService budgetPlanVmCreatorService,
        ILogger<GetBudgetPlanViewCommandHandler> logger)
    {
        _budgetPlanVmCreatorService = budgetPlanVmCreatorService;
        _logger = logger;
    }

    public async Task<BudgetPlanViewModel> Handle(GetBudgetPlanViewCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return await _budgetPlanVmCreatorService.Create(request.BudgetPlanId);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            throw;
        }
    }
}