using FluentValidation;

namespace BudgetPlan.Application.BudgetPlan.Commands.CreateBudgetPlan;

public class CreateBudgetPlanCommandValidator : AbstractValidator<CreateBudgetPlanCommand>
{
    public CreateBudgetPlanCommandValidator()
    {
        RuleFor(x => x.Date).NotEmpty();
    }
}