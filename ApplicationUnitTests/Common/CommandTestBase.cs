using BudgetPlan.Persistence;
using Moq;

namespace ApplicationUnitTests.Common;

public class CommandTestBase : IDisposable
{
    protected readonly BudgetPlanDbContext _context;
    protected readonly Mock<BudgetPlanDbContext> _contextMock;
    
    public CommandTestBase()
    {
        _contextMock = BudgetPlanDbContextFactory.Create();
        _context = _contextMock.Object;
    }
    
    public void Dispose()
    {
        BudgetPlanDbContextFactory.Destroy(_context);
    }
}