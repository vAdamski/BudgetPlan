using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Common.Extension;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlan.Persistence.Respositories;

public class DataAccessRepository(IBudgetPlanDbContext context, ICurrentUserService currentUserService) : IDataAccessRepository
{
	public async Task<DataAccess> GetById(Guid id, CancellationToken cancellationToken = default)
	{
		if (id.IsNullOrEmpty())
			throw new IdIsNullOrEmptyException();
		
		var dataAccess = await context
			.DataAccesses
			.Include(x => x.AccessedPersons)
			.FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);

		if (dataAccess == null)
			throw new NotFoundException(nameof(dataAccess), id);
		
		if (dataAccess.CreatedBy != currentUserService.Email)
			throw new AccessDeniedException();

		return dataAccess;
	}

	public async Task UpdateAsync(DataAccess dataAccess, CancellationToken cancellationToken = default)
	{
		if (dataAccess == null)
			throw new ArgumentNullException(nameof(dataAccess), "DataAccess cannot be null!");
		
		context.DataAccesses.Update(dataAccess);

		await context.SaveChangesAsync(cancellationToken);
	}
}