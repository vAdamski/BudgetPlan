using BudgetPlan.Domain.Common;
using BudgetPlan.Domain.Enums;
using BudgetPlan.Domain.Exceptions;

namespace BudgetPlan.Domain.Entities;

public class TransactionCategory : AuditableEntity
{
    public string TransactionCategoryName { get; private set; }
    public TransactionType TransactionType { get; private set; }

    public Guid? OverTransactionCategoryId { get; private set; }
    public TransactionCategory? OverTransactionCategory { get; private set; }

    public Guid? BudgetPlanId { get; private set; }
    public BudgetPlanEntity? BudgetPlan { get; private set; }

    public Guid? AccessId { get; private set; }
    public DataAccess? Access { get; private set; }

    private List<BudgetPlanDetails> _budgetPlanDetails = new();
    private List<TransactionDetail> _transactionDetails = new();
    private List<TransactionCategory> _subTransactionCategories = new();

    public IReadOnlyCollection<BudgetPlanDetails> BudgetPlanDetails => _budgetPlanDetails.AsReadOnly();
    public IReadOnlyCollection<TransactionDetail> TransactionDetails => _transactionDetails.AsReadOnly();
    public IReadOnlyCollection<TransactionCategory> SubTransactionCategories => _subTransactionCategories.AsReadOnly();

    private TransactionCategory()
    {
    }

    private TransactionCategory(string transactionCategoryName, TransactionType transactionType, Guid dataAccessId)
    {
        if (string.IsNullOrWhiteSpace(transactionCategoryName))
            throw new ArgumentException(nameof(transactionCategoryName), "Transaction category name cannot be empty.");
        
        if (dataAccessId == null)
            throw new ArgumentException(nameof(dataAccessId), "DataAccess id cannot be empty.");

        TransactionCategoryName = transactionCategoryName;
        TransactionType = transactionType;
        AccessId = dataAccessId;
    }

    private TransactionCategory(string transactionCategoryName, TransactionType transactionType,
        Guid overTransactionCategoryId, Guid accessId)
    {
        if (string.IsNullOrWhiteSpace(transactionCategoryName))
            throw new ArgumentException(nameof(transactionCategoryName), "Transaction category name cannot be empty.");

        if (overTransactionCategoryId == null)
            throw new ArgumentException(nameof(overTransactionCategoryId),
                "Over transaction category id cannot be empty.");

        if (accessId == null)
            throw new ArgumentException(nameof(accessId), "DataAccess id cannot be empty.");

        TransactionCategoryName = transactionCategoryName;
        TransactionType = transactionType;
        OverTransactionCategoryId = overTransactionCategoryId;
        AccessId = accessId;
    }

    public TransactionDetail AddTransactionDetail(double transactionValue, string description, DateTime transactionDate,
        Guid dataAccessId)
    {
        var transactionDetail = new TransactionDetail(transactionValue, description, transactionDate, Id, dataAccessId);

        _transactionDetails.Add(transactionDetail);

        return transactionDetail;
    }

    public static TransactionCategory CreateOverTransactionCategory(string transactionCategoryName,
        TransactionType transactionType, Guid dataAccessId)
    {
        return new TransactionCategory(transactionCategoryName, transactionType, dataAccessId);
    }

    public static TransactionCategory CreateUnderTransactionCategory(string transactionCategoryName,
        TransactionType transactionType, Guid overTransactionCategoryId, Guid accessId)
    {
        return new TransactionCategory(transactionCategoryName, transactionType, overTransactionCategoryId, accessId);
    }

    public TransactionCategory AddSubTransactionCategory(string name)
    {
        if (OverTransactionCategoryId != null)
            throw new CannotAddSubTransactionCategoryToSubTransactionCategoryException();
        
        var underTransactionCategory = CreateUnderTransactionCategory(name, TransactionType, Id, AccessId.Value);

        _subTransactionCategories.Add(underTransactionCategory);

        return underTransactionCategory;
    }
}