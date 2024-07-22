using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Persistence;
using BudgetPlan.Tests.Common.MockFactories;
using Moq;

namespace BudgetPlan.Tests.Common;

public class CommandTestBase : IDisposable
{
	protected readonly BudgetPlanDbContext _context;
	protected readonly Mock<BudgetPlanDbContext> _contextMock;
	protected readonly ICurrentUserService _currentUserService;
	protected readonly Mock<ICurrentUserService> _currentUserServiceMock;

	
	public CommandTestBase()
	{
		_contextMock = BudgetPlanDbContextMockFactory.Create();
		_currentUserServiceMock = CurrentUserServiceMockFactory.Create();
		_context = _contextMock.Object;
		_currentUserService = _currentUserServiceMock.Object;
	}
	
	public void Dispose()
	{
		BudgetPlanDbContextMockFactory.Destroy(_contextMock.Object);
	}
}