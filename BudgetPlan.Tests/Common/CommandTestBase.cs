using BudgetPlan.Persistence;
using BudgetPlan.Tests.Common.MockFactories;
using Moq;

namespace BudgetPlan.Tests.Common;

public class CommandTestBase : IDisposable
{
	protected readonly BudgetPlanDbContext _context;
	protected readonly Mock<BudgetPlanDbContext> _contextMock;
	
	public CommandTestBase()
	{
		_contextMock = BudgetPlanDbContextMockFactory.Create();
		_context = _contextMock.Object;
	}
	
	public void Dispose()
	{
		BudgetPlanDbContextMockFactory.Destroy(_contextMock.Object);
	}
}