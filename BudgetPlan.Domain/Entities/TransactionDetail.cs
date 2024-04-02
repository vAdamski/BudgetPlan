using BudgetPlan.Domain.Common;

namespace BudgetPlan.Domain.Entities;

public class TransactionDetail : AuditableEntity
 {
     public double Value { get; private set; }
     public string Description { get; private set; } = "";
     public DateTime TransactionDate { get; private set; }
     
     public Guid? TransactionCategoryId { get; private set; }
     public TransactionCategory? TransactionCategory { get; private set; }
     
     public Guid? AccessId { get; private set; }
     public DataAccess? Access { get; private set; }
     
     private TransactionDetail() { }
 
     public TransactionDetail(double value, string description, DateTime transactionDate, Guid transactionCategoryId, DataAccess dataAccess)
     {
         Value = value;
         Description = description;
         TransactionDate = transactionDate;
         TransactionCategoryId = transactionCategoryId;
         AccessId = dataAccess.Id;
         Access = dataAccess;
     }
 }