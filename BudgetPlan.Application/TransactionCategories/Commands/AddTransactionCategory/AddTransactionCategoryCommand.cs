using MediatR;

namespace BudgetPlan.Application.TransactionCategories.Commands.AddTransactionCategory;

public class AddTransactionCategoryCommand : IRequest<Guid>
{
    public string TransactionCategoryName { get; set; } = "";
    public Guid OverTransactionCategoryId { get; set; }
}