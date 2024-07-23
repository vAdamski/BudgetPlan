using BudgetPlan.Domain.Common;
using BudgetPlan.Domain.Exceptions;

namespace BudgetPlan.Domain.Entities;

public class AccessedPerson : AuditableEntity
{
    public string Email { get; private set; }

    public Guid DataAccessId { get; private set; }
    public DataAccess? DataAccess { get; private set; }

    private AccessedPerson()
    {
    }

    public AccessedPerson(string email, Guid dataAccessId)
    {
        if (string.IsNullOrEmpty(email))
            throw new AccessEmailNullOrEmptyException();
        Email = email;
        DataAccessId = dataAccessId;
    }
}