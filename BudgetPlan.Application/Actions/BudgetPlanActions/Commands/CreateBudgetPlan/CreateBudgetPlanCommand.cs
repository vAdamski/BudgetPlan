using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Domain.Entities;
using MediatR;

namespace BudgetPlan.Application.Actions.BudgetPlanActions.Commands.CreateBudgetPlan;

public class CreateBudgetPlanCommand : IRequest<Guid>
{
    public string Name { get; }
    
    public CreateBudgetPlanCommand(string name)
    {
        Name = name;
    }
}