using FluentValidation;

namespace BudgetPlan.Application.Actions.TransactionCategoriesActions.Commands.AddTransactionCategory;

public class AddTransactionCategoryCommandValidator : AbstractValidator<AddTransactionCategoryCommand>
{
    public AddTransactionCategoryCommandValidator()
    {
        RuleFor(x => x.TransactionCategoryName).MaximumLength(50).NotEmpty();
        RuleFor(x => x.OverTransactionCategoryId).NotNull();
    }
}