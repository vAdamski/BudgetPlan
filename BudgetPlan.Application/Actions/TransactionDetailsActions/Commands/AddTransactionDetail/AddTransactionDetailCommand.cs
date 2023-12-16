using MediatR;

namespace BudgetPlan.Application.Actions.TransactionDetailsActions.Commands.AddTransactionDetail;

public class AddTransactionDetailCommand : IRequest<Guid>
{
    public float Value { get; set; }
    public string Description { get; set; } = "";
    public DateTime TransactionDate { get; set; }
    public Guid TransactionCategoryId { get; set; }
}