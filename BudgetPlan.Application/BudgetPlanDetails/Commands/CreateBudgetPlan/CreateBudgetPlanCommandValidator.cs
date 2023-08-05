using BudgetPlan.Application.BudgetPlanDetails.Commands.CreateBudgetPlanDetailsForMonthView;
using FluentValidation;

namespace BudgetPlan.Application.BudgetPlanDetails.Commands.CreateBudgetPlan;

public class CreateBudgetPlanCommandValidator : AbstractValidator<CreateBudgetPlanCommand>
{
    public CreateBudgetPlanCommandValidator()
    {
        RuleFor(x => x.Date).NotEmpty();
    }
}