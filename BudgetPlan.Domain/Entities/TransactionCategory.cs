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

	public Guid BudgetPlanId { get; private set; }
	public BudgetPlanEntity BudgetPlan { get; private set; }

	public Guid? AccessId { get; private set; }
	public DataAccess? Access { get; private set; }

	private List<BudgetPlanDetails> _budgetPlanDetails = new();
	private List<TransactionDetail> _transactionDetails = new();
	private List<TransactionCategory> _subTransactionCategories = new();

	public IReadOnlyCollection<BudgetPlanDetails> BudgetPlanDetails => _budgetPlanDetails.AsReadOnly();
	public IReadOnlyCollection<TransactionDetail> TransactionDetails => _transactionDetails.AsReadOnly();
	public IReadOnlyCollection<TransactionCategory> SubTransactionCategories => _subTransactionCategories.AsReadOnly();

	public bool IsOverCategory => OverTransactionCategoryId == null;

	private TransactionCategory()
	{
	}

	private TransactionCategory(string transactionCategoryName, Guid budgetPlanId, TransactionType
		transactionType, Guid dataAccessId)
	{
		if (string.IsNullOrWhiteSpace(transactionCategoryName))
			throw new ArgumentException(nameof(transactionCategoryName), "Transaction category name cannot be empty.");

		if (dataAccessId == null)
			throw new ArgumentException(nameof(dataAccessId), "DataAccess id cannot be empty.");

		Id = Guid.NewGuid();
		TransactionCategoryName = transactionCategoryName;
		TransactionType = transactionType;
		AccessId = dataAccessId;
		BudgetPlanId = budgetPlanId;
	}

	private TransactionCategory(string transactionCategoryName, Guid budgetPlanId, TransactionType transactionType,
		Guid overTransactionCategoryId, Guid accessId)
	{
		if (string.IsNullOrWhiteSpace(transactionCategoryName))
			throw new ArgumentException(nameof(transactionCategoryName), "Transaction category name cannot be empty.");

		if (overTransactionCategoryId == null)
			throw new ArgumentException(nameof(overTransactionCategoryId),
				"Over transaction category id cannot be empty.");

		if (accessId == null)
			throw new ArgumentException(nameof(accessId), "DataAccess id cannot be empty.");

		Id = Guid.NewGuid();
		TransactionCategoryName = transactionCategoryName;
		TransactionType = transactionType;
		BudgetPlanId = budgetPlanId;
		OverTransactionCategoryId = overTransactionCategoryId;
		AccessId = accessId;
	}

	public static TransactionCategory CreateOverTransactionCategory(string transactionCategoryName, Guid budgetPlanId,
		TransactionType transactionType, Guid dataAccessId)
	{
		return new TransactionCategory(transactionCategoryName, budgetPlanId, transactionType, dataAccessId);
	}

	public static TransactionCategory CreateUnderTransactionCategory(string transactionCategoryName, Guid budgetPlanId,
		TransactionType transactionType, Guid overTransactionCategoryId, Guid accessId)
	{
		return new TransactionCategory(transactionCategoryName, budgetPlanId, transactionType, overTransactionCategoryId, accessId);
	}

	public TransactionCategory AddSubTransactionCategory(string name)
	{
		if (OverTransactionCategoryId != null)
			throw new CannotAddSubTransactionCategoryToSubTransactionCategoryException();

		var underTransactionCategory = CreateUnderTransactionCategory(name, BudgetPlanId, TransactionType, Id, AccessId.Value);

		_subTransactionCategories.Add(underTransactionCategory);

		return underTransactionCategory;
	}

	public TransactionDetail AddTransactionDetail(double value, string description, DateOnly date)
	{
		TransactionDetail transactionDetails = TransactionDetail.Create(value, description, date, Id, AccessId.Value);

		_transactionDetails.Add(transactionDetails);

		return transactionDetails;
	}

	public void ClearTransactionDetails()
	{
		_transactionDetails.Clear();
	}

	public void AddTransactionDetails(List<TransactionDetail> transactionDetailsToMigrate)
	{
		_transactionDetails.AddRange(transactionDetailsToMigrate);
	}
}