using FluentValidation;

namespace BudgetPlan.Application.TransactionCategories.Commands.AddOverTransactionCategory;

public class AddOverTransactionCategoryCommandValidator : AbstractValidator<AddOverTransactionCategoryCommand>
{
    public AddOverTransactionCategoryCommandValidator()
    {
        RuleFor(x => x.TransactionCategoryName).MaximumLength(50).NotEmpty();
        RuleFor(x => x.TransactionType).IsInEnum().NotNull();
    }
}