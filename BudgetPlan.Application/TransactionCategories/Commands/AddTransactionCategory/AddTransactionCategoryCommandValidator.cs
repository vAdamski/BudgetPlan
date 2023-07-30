using FluentValidation;

namespace BudgetPlan.Application.TransactionCategories.Commands.AddTransactionCategory;

public class AddTransactionCategoryCommandValidator : AbstractValidator<AddTransactionCategoryCommand>
{
    public AddTransactionCategoryCommandValidator()
    {
        RuleFor(x => x.TransactionCategoryName).MaximumLength(50).NotEmpty();
        RuleFor(x => x.TransactionType).NotEmpty();
    }
}