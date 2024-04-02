using BudgetPlan.Domain.Common;
using BudgetPlan.Domain.Enums;
using BudgetPlan.Domain.Exceptions;

namespace BudgetPlan.Domain.Entities;

public class TransactionCategory : AuditableEntity
{
    public string TransactionCategoryName { get; }
    public TransactionType TransactionType { get; }

    public Guid? OverTransactionCategoryId { get; }
    public TransactionCategory? OverTransactionCategory { get; }

    public Guid? BudgetPlanId { get; }
    public BudgetPlanEntity? BudgetPlan { get; }

    public Guid? AccessId { get; }
    public DataAccess? Access { get; }

    private List<BudgetPlanDetails> _budgetPlanDetails = new();
    private List<TransactionDetail> _transactionDetails = new();
    private List<TransactionCategory> _subTransactionCategories = new();

    public IReadOnlyCollection<BudgetPlanDetails> BudgetPlanDetails => _budgetPlanDetails.AsReadOnly();
    public IReadOnlyCollection<TransactionDetail> TransactionDetails => _transactionDetails.AsReadOnly();
    public IReadOnlyCollection<TransactionCategory> SubTransactionCategories => _subTransactionCategories.AsReadOnly();

    private TransactionCategory()
    {
    }

    private TransactionCategory(string transactionCategoryName, TransactionType transactionType, DataAccess dataAccess)
    {
        if (string.IsNullOrWhiteSpace(transactionCategoryName))
            throw new ArgumentException(nameof(transactionCategoryName), "Transaction category name cannot be empty.");
        
        if (dataAccess == null)
            throw new ArgumentException(nameof(dataAccess), "Data access cannot be empty.");
        
        TransactionCategoryName = transactionCategoryName;
        TransactionType = transactionType;
        AccessId = dataAccess.Id;
        Access = dataAccess;
    }

    private TransactionCategory(string transactionCategoryName, TransactionType transactionType,
        Guid overTransactionCategoryId, Guid accessId)
    {
        if (string.IsNullOrWhiteSpace(transactionCategoryName))
            throw new ArgumentException(nameof(transactionCategoryName), "Transaction category name cannot be empty.");
        
        if (overTransactionCategoryId == null)
            throw new ArgumentException(nameof(overTransactionCategoryId), "Over transaction category id cannot be empty.");
        
        if (accessId == null)
            throw new ArgumentException(nameof(accessId), "DataAccess id cannot be empty.");
        
        TransactionCategoryName = transactionCategoryName;
        TransactionType = transactionType;
        OverTransactionCategoryId = overTransactionCategoryId;
        AccessId = accessId;
    }

    public TransactionDetail AddTransactionDetail(double transactionValue, string description, DateTime transactionDate,
        DataAccess dataAccess)
    {
        var transactionDetail = new TransactionDetail(transactionValue, description, transactionDate, Id, dataAccess);

        _transactionDetails.Add(transactionDetail);

        return transactionDetail;
    }

    public static TransactionCategory CreateOverTransactionCategory(string transactionCategoryName,
        TransactionType transactionType, DataAccess access)
    {
        return new TransactionCategory(transactionCategoryName, transactionType, access);
    }

    public static TransactionCategory CreateUnderTransactionCategory(string transactionCategoryName,
        TransactionType transactionType, Guid overTransactionCategoryId, Guid accessId)
    {
        return new TransactionCategory(transactionCategoryName, transactionType, overTransactionCategoryId, accessId);
    }

    public void AddSubTransactionCategory(TransactionCategory transactionCategory)
    {
        if (OverTransactionCategoryId != null)
            throw new CannotAddSubTransactionCategoryToSubTransactionCategoryException();
        
        _subTransactionCategories.Add(transactionCategory);
    }
}