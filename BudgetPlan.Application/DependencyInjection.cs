using System.Reflection;
using BudgetPlan.Application.Common.Behaviours;
using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Application.Common.Interfaces.Services;
using BudgetPlan.Application.Services;
using BudgetPlan.Application.Services.DeleteTransactionCategory;
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
        services.AddTransient<ITransactionCategoryListViewModelFactory, TransactionCategoryListViewModelFactory>();
        services.AddTransient<IBudgetPlanVmCreatorService, BudgetPlanVmCreatorService>();
        services.AddTransient<IDeleteTransactionCategoryService, DeleteTransactionCategoryService>();
        
        // Pipelines
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        
        return services;
    }
}