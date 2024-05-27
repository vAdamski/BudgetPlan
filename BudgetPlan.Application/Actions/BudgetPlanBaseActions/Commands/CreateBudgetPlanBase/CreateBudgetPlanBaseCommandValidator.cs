using FluentValidation;

namespace BudgetPlan.Application.Actions.BudgetPlanBaseActions.Commands.CreateBudgetPlanBase;

public class CreateBudgetPlanBaseCommandValidator : AbstractValidator<CreateBudgetPlanBaseCommand>
{
    public CreateBudgetPlanBaseCommandValidator()
    {
        RuleFor(x => x.DateFrom).NotEmpty();
        RuleFor(x => x.DateTo).NotEmpty().GreaterThan(x => x.DateFrom);
        RuleFor(x => x.BudgetPlanEntityId).NotEmpty();
    }
}