using ApplicationUnitTests.Common;
using AutoMapper;
using BudgetPlan.Application.BudgetPlan.Queries.GetBudgetPlanView;
using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Application.Services;
using BudgetPlan.Persistence;
using BudgetPlan.Persistence.Respositories;
using BudgetPlan.Shared.ViewModels;
using Microsoft.Extensions.Logging;
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
    public async Task Handle_GetBudgetPlanView_GetBudgetPlanViewCommandHandler_ShouldReturnBudgetPlanView()
    {
        // Arrange
        var creatorService = new BudgetPlanVmCreatorService(
            new BudgetPlanBaseRepository(_context, _currentUserService),
            new TransactionCategoriesRepository(_context, _currentUserService),
            new Logger<BudgetPlanBaseRepository>(new LoggerFactory()),
            new TransactionDetailsRepository(_context),
            _currentUserService
            );
        
        var commandHandler = new GetBudgetPlanViewCommandHandler(
            creatorService,
            new Logger<GetBudgetPlanViewCommandHandler>(new LoggerFactory())
            );
        
        var command = new GetBudgetPlanViewCommand
        {
            BudgetPlanId = BudgetPlanDbContextSeedData.BUDGET_PLAN_BASE_1_GUID
        };
        
        // Act
        var result = await commandHandler.Handle(command, CancellationToken.None);
        
        // Assert
        result.ShouldNotBeNull();
        result.ShouldBeOfType<BudgetPlanViewModel>();
        result.Income.ShouldBe(5500);
        result.Expenses.ShouldBe(2000 + 1000 + 140 + 150 + 250);
        result.Balance.ShouldBe(5500 - (2000 + 1000 + 140 + 150 + 250));
        result.BudgetPlanOverTransactionCategoryDtos.ShouldNotBeNull();
        result.BudgetPlanOverTransactionCategoryDtos.Count.ShouldBe(3);
        result.BudgetPlanOverTransactionCategoryDtos.First(x => x.OverCategoryName == "Earnings").UnderTransactionCategoryDtos.First(x => x.UnderCategoryName == "Work").BudgetPlanDetailsDto.AmountAllocated.ShouldBe(5500);
        result.BudgetPlanOverTransactionCategoryDtos.First(x => x.OverCategoryName == "Home").UnderTransactionCategoryDtos.First(x => x.UnderCategoryName == "Food").BudgetPlanDetailsDto.AmountAllocated.ShouldBe(1500);
        result.BudgetPlanOverTransactionCategoryDtos.First(x => x.OverCategoryName == "Home").UnderTransactionCategoryDtos.First(x => x.UnderCategoryName == "Rent").BudgetPlanDetailsDto.AmountAllocated.ShouldBe(2000);
        result.BudgetPlanOverTransactionCategoryDtos.First(x => x.OverCategoryName == "Others").UnderTransactionCategoryDtos.First(x => x.UnderCategoryName == "Car fuel").BudgetPlanDetailsDto.AmountAllocated.ShouldBe(500);
        result.BudgetPlanOverTransactionCategoryDtos.First(x => x.OverCategoryName == "Others").UnderTransactionCategoryDtos.First(x => x.UnderCategoryName == "Education").BudgetPlanDetailsDto.AmountAllocated.ShouldBe(1000);
    }
}