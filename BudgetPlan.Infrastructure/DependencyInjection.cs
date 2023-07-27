using System.Reflection;
using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetPlan.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IDateTime, DateTimeService>();

        return services;
    }
}