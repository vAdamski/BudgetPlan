using AutoMapper;

namespace BudgetPlan.Application.Common.Interfaces;

public interface IMapFrom<T>
{
    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
}