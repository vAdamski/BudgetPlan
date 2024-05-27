using FluentValidation;

namespace BudgetPlan.Application.Actions.BudgetPlanActions.Commands.CreateBudgetPlan;

public class CreateBudgetPlanCommandValidator : AbstractValidator<CreateBudgetPlanCommand>
{
    public CreateBudgetPlanCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
    }
}