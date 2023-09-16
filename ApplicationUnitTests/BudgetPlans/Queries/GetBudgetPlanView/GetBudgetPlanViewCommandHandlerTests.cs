using ApplicationUnitTests.Common;
using AutoMapper;
using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Persistence;
using Xunit;

namespace ApplicationUnitTests.BudgetPlans.Queries.GetBudgetPlanView;

[Collection("QueryCollection")]
public class GetBudgetPlanViewCommandHandlerTests
{
    private readonly ICurrentUserService _currentUserService;
    private readonly BudgetPlanDbContext _context;
    private readonly IMapper _mapper;

    public GetBudgetPlanViewCommandHandlerTests(QueryTestFixtures fixtures)
    {
        _context = fixtures.Context;
        _mapper = fixtures.Mapper;
        _currentUserService = fixtures.CurrentUserService;
    }
}