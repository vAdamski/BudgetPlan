using FluentValidation;

namespace BudgetPlan.Application.TransactionDetails.Commands.AddTransactionDetail;

public class AddTransactionDetailCommandValidator : AbstractValidator<AddTransactionDetailCommand>
{
    public AddTransactionDetailCommandValidator()
    {
        RuleFor(x => x.Value).GreaterThanOrEqualTo(0).NotEmpty();
        RuleFor(x => x.Description).MaximumLength(255).NotEmpty();
        RuleFor(x => x.TransactionCategoryId).NotEmpty();
    }
}