using BudgetPlan.Domain.Common;
using BudgetPlan.Domain.Exceptions;

namespace BudgetPlan.Domain.Entities;

public class AccessedPerson : AuditableEntity
{
    public string Email { get; private set; }

    public Guid? AccessId { get; private set; }
    public Access? Access { get; private set; }

    private AccessedPerson()
    {
    }

    public AccessedPerson(Guid accessId, string email)
    {
        if (accessId == Guid.Empty)
            throw new AccessIdNullOrEmptyException();

        if (string.IsNullOrEmpty(email))
            throw new AccessEmailNullOrEmptyException();

        AccessId = accessId;
        Email = email;
    }
}