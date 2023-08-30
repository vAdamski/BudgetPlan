using System.Security.Claims;
using BudgetPlan.Api.Services;
using BudgetPlan.Application.Common.Interfaces;
using IdentityModel;
using Microsoft.AspNetCore.Http;
using Moq;

namespace ApplicationUnitTests.Common;

public static class CurrentUserServiceFactory
{
    public static Mock<ICurrentUserService> Create()
    {
        return Create("user@user.pl", "UserName","UserFirstName", "UserLastName", true);
    }
    
    public static Mock<ICurrentUserService> Create(
        string email,
        string name,
        string firstName,
        string lastName,
        bool isAuthenticated)
    {
        var mockCurrentUserService = new Mock<ICurrentUserService>();
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