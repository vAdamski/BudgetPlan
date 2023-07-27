using BudgetPlan.Application.Common.Interfaces;

namespace BudgetPlan.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}