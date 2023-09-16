using ApplicationUnitTests.Common;
using BudgetPlan.Application.BudgetPlan.Commands.CreateBudgetPlan;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;

namespace ApplicationUnitTests.BudgetPlans.Commands.CreateBudgetPlan;

public class CreateBudgetPlanCommandHandlerTests : CommandTestBase
{
    private readonly CreateBudgetPlanCommandHandler _handler;

    public CreateBudgetPlanCommandHandlerTests() : base()
    {
        _handler = new CreateBudgetPlanCommandHandler(_context, _currentUserService);
    }

    [Fact]
    public async Task Handle_GivenValidCommand_ShouldCreateBudgetPlanWithAllCategories()
    {
        // Arrange
        var todayDate = DateTime.Today;
        var dateTimeFirstDayOfCurrentMonth = GetDateWithFirstDayOfCurrentMonth();
        var dateTimeLastDayOfCurrentMonth = GetDateWithLastDayOfCurrentMonth();

        var command = new CreateBudgetPlanCommand(todayDate);

        var nextBudgetPlanId = GetNextExpectedBudgetPlanId();

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Equal(nextBudgetPlanId, result);

        var underCategoriesCount = GetCountOfUnderCategoriesForCurrentUser();

        var budgetPlan = await _context.BudgetPlans.Where(x => x.CreatedBy == _currentUserService.Email && x.Id == result)
            .Include(x => x.BudgetPlanDetailsList).FirstOrDefaultAsync();

        budgetPlan.ShouldNotBeNull();
        budgetPlan.DateFrom.ShouldBe(dateTimeFirstDayOfCurrentMonth);
        budgetPlan.DateTo.ShouldBe(dateTimeLastDayOfCurrentMonth);
        budgetPlan.BudgetPlanDetailsList.Count.ShouldBe(underCategoriesCount);
    }
    
    private DateTime GetDateWithFirstDayOfCurrentMonth()
    {
        var date = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        return date;
    }
    
    private DateTime GetDateWithLastDayOfCurrentMonth()
    {
        var date = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));
        return date;
    }

    private int GetCountOfUnderCategoriesForCurrentUser()
    {
        var underCategoriesCount = _context.TransactionCategories
            .Count(x => x.StatusId == 1 && 
                        x.OverTransactionCategoryId != null && 
                        x.CreatedBy == _currentUserService.Email);

        return underCategoriesCount;
    }
    
    private int GetNextExpectedBudgetPlanId()
    {
        var lastBudgetPlanId = _context.BudgetPlans.Max(x => x.Id);
        var nextBudgetPlanId = lastBudgetPlanId + 1;
        return nextBudgetPlanId;
    }
}