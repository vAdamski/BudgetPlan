using ApplicationUnitTests.Common;
using BudgetPlan.Application.Actions.BudgetPlanBaseActions.Commands.CreateBudgetPlanBase;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;

namespace ApplicationUnitTests.BudgetPlans.Commands.CreateBudgetPlan;

public class CreateBudgetPlanBaseCommandHandlerTests : CommandTestBase
{
    private readonly CreateBudgetPlanBaseCommandHandler _handler;

    public CreateBudgetPlanBaseCommandHandlerTests() : base()
    {
        _handler = new CreateBudgetPlanBaseCommandHandler(_context, _currentUserService);
    }

    [Fact]
    public async Task Handle_GivenValidCommand_ShouldCreateBudgetPlanWithAllCategories()
    {
        // Arrange
        var todayDate = DateTime.Today;
        var dateTimeFirstDayOfCurrentMonth = GetDateWithFirstDayOfCurrentMonth();
        var dateTimeLastDayOfCurrentMonth = GetDateWithLastDayOfCurrentMonth();

        var command = new CreateBudgetPlanBaseCommand(todayDate);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        var underCategoriesCount = GetCountOfUnderCategoriesForCurrentUser();

        var budgetPlan = await _context.BudgetPlanBases
            .Where(x => x.CreatedBy == _currentUserService.Email && x.Id == result)
            .Include(x => x.BudgetPlanDetailsList).FirstOrDefaultAsync();

        budgetPlan.ShouldNotBeNull();
        budgetPlan.DateFrom.ShouldBe(dateTimeFirstDayOfCurrentMonth);
        budgetPlan.DateTo.ShouldBe(dateTimeLastDayOfCurrentMonth);
        budgetPlan.BudgetPlanDetailsList.Count.ShouldBe(underCategoriesCount);
    }

    [Fact]
    public async Task Handle_GivenValidCommand_ShouldCreateAccessWithCurrentUserMail()
    {
        // Arrange
        var todayDate = DateTime.Today;
        var dateTimeFirstDayOfCurrentMonth = GetDateWithFirstDayOfCurrentMonth();
        var dateTimeLastDayOfCurrentMonth = GetDateWithLastDayOfCurrentMonth();

        var command = new CreateBudgetPlanBaseCommand(todayDate);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        var budgetPlan = await _context.BudgetPlanBases
            .Where(x => x.CreatedBy == _currentUserService.Email && x.Id == result)
            .Include(x => x.DataAccess)
            .ThenInclude(x => x.AccessedPersons)
            .FirstOrDefaultAsync();

        budgetPlan.ShouldNotBeNull();
        budgetPlan.DataAccess.ShouldNotBeNull();
        budgetPlan.DataAccess.AccessedPersons.Count.ShouldBe(1);
        budgetPlan.DataAccess.IsAccessed(_currentUserService.Email).ShouldBe(true);
    }

    private DateTime GetDateWithFirstDayOfCurrentMonth()
    {
        var date = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        return date;
    }

    private DateTime GetDateWithLastDayOfCurrentMonth()
    {
        var date = new DateTime(DateTime.Today.Year, DateTime.Today.Month,
            DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));
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
}