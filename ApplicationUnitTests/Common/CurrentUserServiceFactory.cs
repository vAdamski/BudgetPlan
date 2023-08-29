using System.Security.Claims;
using BudgetPlan.Api.Services;
using BudgetPlan.Application.Common.Interfaces;
using IdentityModel;
using Microsoft.AspNetCore.Http;
using Moq;

namespace ApplicationUnitTests.Common;

public static class CurrentUserServiceFactory
{
    public static Mock<CurrentUserService> Create()
    {
        return Create("user@user.pl", "UserName","UserFirstName", "UserLastName", true);
    }
    
    public static Mock<CurrentUserService> Create(
        string email,
        string name,
        string firstName,
        string lastName,
        bool isAuthenticated)
    {
        var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
        var httpContextMock = new Mock<HttpContext>();
        var userMock = new Mock<ClaimsPrincipal>();

        if (!string.IsNullOrEmpty(email))
        {
            userMock.Setup(u => u.FindFirstValue(It.IsAny<string>()))
                .Returns(email)
                .Verifiable();
        }

        if (!string.IsNullOrEmpty(name))
        {
            userMock.Setup(u => u.FindFirstValue(JwtClaimTypes.Name))
                .Returns(name)
                .Verifiable();
        }

        if (!string.IsNullOrEmpty(firstName))
        {
            userMock.Setup(u => u.FindFirstValue("firstName"))
                .Returns(firstName)
                .Verifiable();
        }

        if (!string.IsNullOrEmpty(lastName))
        {
            userMock.Setup(u => u.FindFirstValue("lastName"))
                .Returns(lastName)
                .Verifiable();
        }

        httpContextMock.Setup(c => c.User)
            .Returns(userMock.Object);

        httpContextAccessorMock.Setup(a => a.HttpContext)
            .Returns(httpContextMock.Object);

        var mockCurrentUserService = new Mock<CurrentUserService>(httpContextAccessorMock.Object);
        mockCurrentUserService.SetupGet(s => s.Email)
            .Returns(email);
        mockCurrentUserService.SetupGet(s => s.Name)
            .Returns(name);
        mockCurrentUserService.SetupGet(s => s.FirstName)
            .Returns(firstName);
        mockCurrentUserService.SetupGet(s => s.LastName)
            .Returns(lastName);
        mockCurrentUserService.SetupGet(s => s.FullName)
            .Returns($"{firstName} {lastName}");
        mockCurrentUserService.SetupGet(s => s.IsAuthenticated)
            .Returns(isAuthenticated);

        return mockCurrentUserService;
    }
}