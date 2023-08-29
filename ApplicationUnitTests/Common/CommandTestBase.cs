using BudgetPlan.Api.Services;
using BudgetPlan.Persistence;
using Moq;

namespace ApplicationUnitTests.Common;

public class CommandTestBase : IDisposable
{
    protected readonly BudgetPlanDbContext _context;
    protected readonly Mock<BudgetPlanDbContext> _contextMock;
    protected readonly CurrentUserService _currentUserService;
    protected readonly Mock<CurrentUserService> _currentUserServiceMock;

    public CommandTestBase()
    {
        _contextMock = BudgetPlanDbContextFactory.Create();
        _context = _contextMock.Object;

        _currentUserServiceMock = CurrentUserServiceFactory.Create();
        _currentUserService = _currentUserServiceMock.Object;
    }
    
    public void Dispose()
    {
        BudgetPlanDbContextFactory.Destroy(_context);
    }
}