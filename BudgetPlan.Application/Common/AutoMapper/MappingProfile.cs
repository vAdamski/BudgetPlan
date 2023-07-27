using System.Reflection;
using AutoMapper;
using BudgetPlan.Application.Common.Interfaces;

namespace BudgetPlan.Application.Common.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
    }

    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        var types = assembly.GetExportedTypes().Where(p =>
                p.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
            .ToList();

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);

            var methodInfo = type.GetMethod("Mapping");
            methodInfo.Invoke(instance, new object[] { this });
        }
    }
}