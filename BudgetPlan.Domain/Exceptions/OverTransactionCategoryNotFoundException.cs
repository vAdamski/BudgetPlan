namespace BudgetPlan.Domain.Exceptions;

public class OverTransactionCategoryNotFoundException(Guid message) : Exception($"OverTransactionCategory with id {message} not found.");