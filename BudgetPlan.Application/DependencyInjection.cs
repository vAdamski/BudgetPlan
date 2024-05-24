using System.Reflection;
using BudgetPlan.Application.Common.Behaviours;
using BudgetPlan.Application.Common.Interfaces.Managers;
using BudgetPlan.Application.Managers;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetPlan.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // DI
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        // Services
        services.AddTransient<ITransactionCategoryManager, TransactionCategoryManager>();
        services.AddTransient<IBudgetPlanManager, BudgetPlanManager>();
        
        // Pipelines
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        
        return services;
    }
}