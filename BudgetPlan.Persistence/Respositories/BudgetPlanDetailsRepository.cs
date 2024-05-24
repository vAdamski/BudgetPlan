using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlan.Persistence.Respositories;

public class BudgetPlanDetailsRepository(
    IBudgetPlanDbContext context,
    ICurrentUserService currentUserService)
    : IBudgetPlanDetailsRepository
{
    
}