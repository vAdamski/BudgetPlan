using BudgetPlan.Shared.Dtos;
using MediatR;

namespace BudgetPlan.Application.BudgetPlanDetailsActions.Commands.UpdateBudgetPlanDetail;

public class UpdateBudgetPlanDetailCommand : IRequest
{
    public UpdateBudgetPlanDetailCommand()
    {
        
    }
    
    public UpdateBudgetPlanDetailCommand(UpdateBudgetPlanDetailDto dto)
    {
        Id = dto.Id;
        ExpectedAmount = dto.ExpectedAmount;
    }
    
    public Guid Id { get; set; }
    public double ExpectedAmount { get; set; }
}