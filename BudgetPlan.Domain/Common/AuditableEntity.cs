namespace BudgetPlan.Domain.Common;

public class AuditableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string CreatedBy { get; set; } = "";
    public DateTime Created { get; set; }
    public string ModifiedBy { get; set; } = "";
    public DateTime Modified { get; set; }
    public int StatusId { get; set; }
    public string InactivatedBy { get; set; } = "";
    public DateTime? Inactivated { get; set; }
    
    public bool IsActive => StatusId == 1;
}