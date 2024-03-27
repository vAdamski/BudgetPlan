using FluentValidation;

namespace BudgetPlan.Application.Actions.BudgetPlanActions.Commands.CreateBudgetPlan;

public class CreateBudgetPlanCommandValidator : AbstractValidator<CreateBudgetPlanCommand>
{
    public CreateBudgetPlanCommandValidator()
    {
        // RuleFor(v => v.Name)
        //     .MaximumLength(200)
        //     .NotEmpty();
    }
}