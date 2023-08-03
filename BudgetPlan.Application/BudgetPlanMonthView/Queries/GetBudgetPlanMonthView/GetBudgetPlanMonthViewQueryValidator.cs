using FluentValidation;

namespace BudgetPlan.Application.BudgetPlanMonthView.Queries.GetBudgetPlanMonthView;

public class GetBudgetPlanMonthViewQueryValidator : AbstractValidator<GetBudgetPlanMonthViewQuery>
{
    public GetBudgetPlanMonthViewQueryValidator()
    {
        RuleFor(x => x.DateTime).NotEmpty();
    }
}