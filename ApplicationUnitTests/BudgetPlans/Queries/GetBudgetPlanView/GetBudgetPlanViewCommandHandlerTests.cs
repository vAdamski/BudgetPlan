using ApplicationUnitTests.Common;
using ApplicationUnitTests.Common.Mocks;
using AutoMapper;
using BudgetPlan.Application.Actions.BudgetPlanActions.Queries.GetBudgetPlanView;
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
            new TransactionCategoriesRepository(_context, _currentUserService, LoggerMockFactory<TransactionCategoriesRepository>.Create()),
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
        
        var from = _context.BudgetPlanBases.First(x => x.Id == BudgetPlanDbContextSeedData.BUDGET_PLAN_BASE_1_GUID).DateFrom;
        var to = _context.BudgetPlanBases.First(x => x.Id == BudgetPlanDbContextSeedData.BUDGET_PLAN_BASE_1_GUID).DateTo;
        
        var daysCount = (to - from).Days + 1;
        
        // Assert
        result.ShouldNotBeNull();
        result.ShouldBeOfType<BudgetPlanViewModel>();
        result.Income.ShouldBe(5500);
        result.Expenses.ShouldBe(2000 + 1000 + 140 + 150 + 250);
        result.Balance.ShouldBe(5500 - (2000 + 1000 + 140 + 150 + 250));
        result.BudgetPlanOverTransactionCategoryDtos.ShouldNotBeNull();
        result.BudgetPlanOverTransactionCategoryDtos.Count.ShouldBe(3);
        GetBudgetPlanDetailsDtoAmountAllocated(result, "Earnings", "Work").ShouldBe(5500);
        GetBudgetPlanDetailsDtoId(result, "Earnings", "Work").ShouldBe(BudgetPlanDbContextSeedData.BUDGET_PLAN_DETAILS_1_GUID);
        GetBudgetPlanDetailsDtoAmountAllocated(result, "Home", "Food").ShouldBe(1500);
        GetBudgetPlanDetailsDtoId(result, "Home", "Food").ShouldBe(BudgetPlanDbContextSeedData.BUDGET_PLAN_DETAILS_2_GUID);
        GetBudgetPlanDetailsDtoAmountAllocated(result, "Home", "Rent").ShouldBe(2000);
        GetBudgetPlanDetailsDtoId(result, "Home", "Rent").ShouldBe(BudgetPlanDbContextSeedData.BUDGET_PLAN_DETAILS_3_GUID);
        GetBudgetPlanDetailsDtoAmountAllocated(result, "Others", "Car fuel").ShouldBe(500);
        GetBudgetPlanDetailsDtoId(result, "Others", "Car fuel").ShouldBe(BudgetPlanDbContextSeedData.BUDGET_PLAN_DETAILS_4_GUID);
        GetBudgetPlanDetailsDtoAmountAllocated(result, "Others", "Education").ShouldBe(1000);
        GetBudgetPlanDetailsDtoId(result, "Others", "Education").ShouldBe(BudgetPlanDbContextSeedData.BUDGET_PLAN_DETAILS_5_GUID);
        
        result.BudgetPlanOverTransactionCategoryDtos.ForEach(otc =>
        {
            otc.UnderTransactionCategoryDtos.ForEach(utc =>
            {
                utc.BudgetPlanDetailsDto.TransactionItemsForDaysDtos.Count.ShouldBe(daysCount);
            });
        });
    }
    
    private double GetBudgetPlanDetailsDtoAmountAllocated(BudgetPlanViewModel vm, string overCategoryName, string underCategoryName)
    {
        return vm.BudgetPlanOverTransactionCategoryDtos.First(x => x.OverCategoryName == overCategoryName).UnderTransactionCategoryDtos.First(x => x.UnderCategoryName == underCategoryName).BudgetPlanDetailsDto.AmountAllocated;
    }
    
    private Guid GetBudgetPlanDetailsDtoId(BudgetPlanViewModel vm, string overCategoryName, string underCategoryName)
    {
        return vm.BudgetPlanOverTransactionCategoryDtos.First(x => x.OverCategoryName == overCategoryName).UnderTransactionCategoryDtos.First(x => x.UnderCategoryName == underCategoryName).BudgetPlanDetailsDto.Id;
    }
}