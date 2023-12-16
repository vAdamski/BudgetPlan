using FluentValidation;

namespace BudgetPlan.Application.Actions.TransactionDetailsActions.Commands.AddTransactionDetail;

public class AddTransactionDetailCommandValidator : AbstractValidator<AddTransactionDetailCommand>
{
    public AddTransactionDetailCommandValidator()
    {
        RuleFor(x => x.Value).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Description).MaximumLength(255);
        RuleFor(x => x.TransactionCategoryId).NotEmpty();
    }
}