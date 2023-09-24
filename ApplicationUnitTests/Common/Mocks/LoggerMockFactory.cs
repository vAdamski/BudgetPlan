using BudgetPlan.Application.TransactionDetails.Commands.AddTransactionDetail;
using Microsoft.Extensions.Logging;
using Moq;

namespace ApplicationUnitTests.Common.Mocks;

public static class LoggerMockFactory<T>
{
    public static ILogger<T> Create()
    {
        return new Mock<ILogger<T>>().Object;
    }
}