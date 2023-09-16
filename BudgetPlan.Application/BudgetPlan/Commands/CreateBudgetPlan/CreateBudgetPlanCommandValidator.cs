using FluentValidation;

namespace BudgetPlan.Application.BudgetPlan.Commands.CreateBudgetPlan;

public class CreateBudgetPlanCommandValidator : AbstractValidator<CreateBudgetPlanCommand>
{
    public CreateBudgetPlanCommandValidator()
    {
        RuleFor(x => x.Year).NotEmpty();
        RuleFor(x => x.Month).NotEmpty();
    }
}