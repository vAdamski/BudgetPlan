using ApplicationUnitTests.Common;
using AutoMapper;
using BudgetPlan.Application.BudgetPlan.Queries.GetBudgetPlanView;
using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Persistence;
using BudgetPlan.Shared.ViewModels;
using Shouldly;
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

    [Fact]
    public async Task GetBudgetPlanViewCommandHandler_ShouldReturnBudgetPlanView()
    {
        // Arrange
        var sut = new GetBudgetPlanViewCommandHandler(_context, _currentUserService);
        var command = new GetBudgetPlanViewCommand
        {
            BudgetPlanId = BudgetPlanDbContextSeedData.BUDGET_PLAN_BASE_1_GUID
        };
        
        // Act
        var result = await sut.Handle(command, CancellationToken.None);
        
        // Assert
        result.ShouldNotBeNull();
        result.ShouldBeOfType<BudgetPlanViewModel>();
        result.Income.ShouldBe(5500);
        result.Expenses.ShouldBe(2000 + 1000 + 140 + 150 + 250);
        result.Balance.ShouldBe(5500 - (2000 + 1000 + 140 + 150 + 250));
        result.BudgetPlanOverTransactionCategoryDtos.ShouldNotBeNull();
        result.BudgetPlanOverTransactionCategoryDtos.Count.ShouldBe(3);
    }
}