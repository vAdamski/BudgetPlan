using BudgetPlan.Domain.Common;

namespace BudgetPlan.Domain.Entities;

public class TransactionDetail : AuditableEntity
 {
     public double Value { get; private set; }
     public string Description { get; private set; } = "";
     public DateOnly TransactionDate { get; private set; }
     
     public Guid? TransactionCategoryId { get; private set; }
     public TransactionCategory? TransactionCategory { get; private set; }
     
     public Guid? AccessId { get; private set; }
     public DataAccess? Access { get; private set; }

     private TransactionDetail()
     {
         
     }
     
     private TransactionDetail(double value, string description, DateOnly transactionDate, Guid transactionCategoryId, Guid dataAccessId)
     {
         Value = value;
         Description = description;
         TransactionDate = transactionDate;
         TransactionCategoryId = transactionCategoryId;
         AccessId = dataAccessId;
     }

     public static TransactionDetail Create(double value, string description, DateOnly transactionDate,
         Guid transactionCategoryId, Guid dataAccessId)
     {
         return new TransactionDetail(value, description, transactionDate, transactionCategoryId, dataAccessId);
     }
 }