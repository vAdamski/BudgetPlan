using BudgetPlan.Domain.Common;
using BudgetPlan.Domain.Exceptions;

namespace BudgetPlan.Domain.Entities;

public class DataAccess : AuditableEntity
{
    public List<AccessedPerson> AccessedPersons { get; private set; } = new();
    
    public List<BudgetPlanEntity> BudgetPlanEntities { get; private set; } = new();
    public List<BudgetPlanBase> BudgetPlanBases { get; private set; } = new();
    public List<BudgetPlanDetails> BudgetPlanDetails { get; private set; } = new();
    public List<TransactionCategory> TransactionCategories { get; private set; } = new();
    public List<TransactionDetail> TransactionDetails { get; private set; } = new();

    private DataAccess() { }

    public void AddPerson(string email)
    {
        if (string.IsNullOrEmpty(email))
            throw new AccessEmailNullOrEmptyException();

        if (IsAccessed(email))
            throw new CurrentEmailIsAlreadyAccessedException(email);

        AccessedPersons.Add(new AccessedPerson(email));
    }

    public void RemovePerson(string email)
    {
        if (string.IsNullOrEmpty(email))
            throw new AccessEmailNullOrEmptyException();

        var person = AccessedPersons.FirstOrDefault(p => p.Email == email);
        
        if (person is null)
            throw new CurrentEmailIsAlreadyAccessedException(email);

        AccessedPersons.Remove(person);
    }

    public bool IsAccessed(string email)
    {
        return AccessedPersons.Any(p => p.Email == email);
    }
    
    public static DataAccess Create(string email)
    {
        var access = new DataAccess();
        access.AddPerson(email);
        return access;
    }

    public void OverrideAccessedPersons(List<AccessedPerson> accessedPersons)
    {
        AccessedPersons = accessedPersons;
    }
}