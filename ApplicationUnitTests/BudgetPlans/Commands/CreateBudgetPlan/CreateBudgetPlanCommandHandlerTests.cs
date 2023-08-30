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
        var command = new CreateBudgetPlanCommand()
        {
            Date = new DateTime(2023, 8, 1)
        };

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Equal(1, result);

        var underCategoriesCount = _context.TransactionCategories
            .Count(x => x.StatusId == 1 && x.OverTransactionCategoryId != null);

        var budgetPlan = _context.BudgetPlans.Where(x => x.CreatedBy == _currentUserService.Email)
            .Include(x => x.BudgetPlanDetailsList).FirstOrDefault();
        
        budgetPlan.BudgetPlanDetailsList.Count.ShouldBe(underCategoriesCount);
    }
}