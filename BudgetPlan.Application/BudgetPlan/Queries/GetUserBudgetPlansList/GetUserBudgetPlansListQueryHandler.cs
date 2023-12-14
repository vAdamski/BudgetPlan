using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Domain.Exceptions;
using BudgetPlan.Shared.Dtos;
using BudgetPlan.Shared.ViewModels;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BudgetPlan.Application.BudgetPlan.Queries.GetUserBudgetPlansList;

public class GetUserBudgetPlansListQueryHandler : IRequestHandler<GetUserBudgetPlansListQuery, BudgetPlanListViewModel>
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IBudgetPlanBaseRepository _budgetPlanBaseRepository;
    private readonly ILogger<GetUserBudgetPlansListQueryHandler> _logger;

    public GetUserBudgetPlansListQueryHandler(ICurrentUserService currentUserService,
        IBudgetPlanBaseRepository budgetPlanBaseRepository,
        ILogger<GetUserBudgetPlansListQueryHandler> logger)
    {
        _currentUserService = currentUserService;
        _budgetPlanBaseRepository = budgetPlanBaseRepository;
        _logger = logger;
    }
    
    public async Task<BudgetPlanListViewModel> Handle(GetUserBudgetPlansListQuery request, CancellationToken cancellationToken)
    {
        var userEmail = _currentUserService.Email;
        
        if (userEmail == null)
            throw new UserEmailNotFoundInTokenException();

        List<BudgetPlanBase> budgetPlanBases;
        try
        {   
            budgetPlanBases = await _budgetPlanBaseRepository.GetBudgetPlansForUser(userEmail, cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while getting budget plans for user {UserEmail}", userEmail);
            throw;
        }

        List<BudgetPlanListItemDto> budgetPlansItemDtos =
            budgetPlanBases.Select(x => new BudgetPlanListItemDto(x)).ToList();
        
        return new BudgetPlanListViewModel(budgetPlansItemDtos);
    }
}