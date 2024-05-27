using BudgetPlan.Shared.Dtos;

namespace BudgetPlan.Shared.ViewModels;

public class UpdateDataAccessViewModel
{
	public Guid AccessId { get; set; }
	public List<UpdateDataAccessItemDto> AccessPersonDtos { get; set; } = new();
}