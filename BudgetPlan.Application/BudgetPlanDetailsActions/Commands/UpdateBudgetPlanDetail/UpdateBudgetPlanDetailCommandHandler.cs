using BudgetPlan.Application.Common.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BudgetPlan.Application.BudgetPlanDetailsActions.Commands.UpdateBudgetPlanDetail;

public class UpdateBudgetPlanDetailCommandHandler : IRequestHandler<UpdateBudgetPlanDetailCommand>
{
    private readonly IBudgetPlanDetailsRepository _budgetPlanDetailsRepository;
    private readonly ILogger<UpdateBudgetPlanDetailCommandHandler> _logger;

    public UpdateBudgetPlanDetailCommandHandler(IBudgetPlanDetailsRepository budgetPlanDetailsRepository,
        ILogger<UpdateBudgetPlanDetailCommandHandler> logger)
    {
        _budgetPlanDetailsRepository = budgetPlanDetailsRepository;
        _logger = logger;
    }
    
    public async Task Handle(UpdateBudgetPlanDetailCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _budgetPlanDetailsRepository.UpdateBudgetPlanDetail(request.Id, request.ExpectedAmount);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            throw;
        }
    }
}