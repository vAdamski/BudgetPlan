using ApplicationUnitTests.Common;
using AutoMapper;
using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Domain.Exceptions;
using BudgetPlan.Persistence;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;

namespace ApplicationUnitTests.Repositories.BudgetPlanBaseRepository;

[Collection("QueryCollection")]
public class BudgetPlanRepositoryTests
{
    private readonly ICurrentUserService _currentUserService;
    private readonly BudgetPlanDbContext _context;
    private readonly IMapper _mapper;

    public BudgetPlanRepositoryTests(QueryTestFixtures fixtures)
    {
        _context = fixtures.Context;
        _mapper = fixtures.Mapper;
        _currentUserService = fixtures.CurrentUserService;
    }
    
    
    [Fact]
    public async Task DeleteAsync_DeleteBudgetPlanBase_ShouldSoftDeleteAllComponentsBoundedToBudgetPlanBase()
    {
        // Arrange
        var repository = new BudgetPlan.Persistence.Respositories.BudgetPlanBaseRepository(_context, _currentUserService);
        var budgetPlanBase = await _context.BudgetPlanBases.FirstOrDefaultAsync();
        
        // Act
        await repository.DeleteAsync(budgetPlanBase);
        
        // Assert
        var deletedBudgetPlanBase = await _context.BudgetPlanBases.FirstOrDefaultAsync(x => x.Id == budgetPlanBase.Id);
        deletedBudgetPlanBase.StatusId.ShouldBe(0);
        var budgetPlanDetails = await _context.BudgetPlanDetails.Where(x => x.BudgetPlanBaseId == budgetPlanBase.Id).ToListAsync();
        budgetPlanDetails.ForEach(x => x.StatusId.ShouldBe(0));
    }
    
    [Fact]
    public async Task DeleteAsync_DeleteBudgetPlanBaseById_ShouldSoftDeleteAllComponentsBoundedToBudgetPlanBase()
    {
        // Arrange
        var repository = new BudgetPlan.Persistence.Respositories.BudgetPlanBaseRepository(_context, _currentUserService);
        var guidBudgetPlanBaseToDelete = BudgetPlanDbContextSeedData.BUDGET_PLAN_BASE_1_GUID;
        
        // Act
        await repository.DeleteAsync(guidBudgetPlanBaseToDelete);
        
        // Assert
        var deletedBudgetPlanBase = await _context.BudgetPlanBases.FirstOrDefaultAsync(x => x.Id == guidBudgetPlanBaseToDelete);
        deletedBudgetPlanBase.StatusId.ShouldBe(0);
        var budgetPlanDetails = await _context.BudgetPlanDetails.Where(x => x.BudgetPlanBaseId == guidBudgetPlanBaseToDelete).ToListAsync();
        budgetPlanDetails.ForEach(x => x.StatusId.ShouldBe(0));
    }
    
    [Fact]
    public async Task GetActiveBudgetPlansBasesForCurrentUser_GetList_ShouldReturnValidList()
    {
        // Arrange
        var repository = new BudgetPlan.Persistence.Respositories.BudgetPlanBaseRepository(_context, _currentUserService);
        
        // Act
        var result = await repository.GetActiveBudgetPlansBasesForCurrentUser();
        
        // Assert
        result.ShouldNotBeNull();
        result.ForEach(x => x.StatusId.ShouldBe(1));
    }

    [Fact]
    public async Task GetById_GetBudgetPlanBase_GivenValidId_ShouldReturnBudgetPlanBase()
    {
        // Arrange
        var repository = new BudgetPlan.Persistence.Respositories.BudgetPlanBaseRepository(_context, _currentUserService);
        var validId = BudgetPlanDbContextSeedData.BUDGET_PLAN_BASE_1_GUID;
        
        // Act
        var result = await repository.GetById(validId);
        
        // Assert
        result.ShouldNotBeNull();
        result.Id.ShouldBe(validId);
        result.StatusId.ShouldBe(1);
    }
    
    [Fact]
    public async Task GetById_GetBudgetPlanBase_GivenInvalidId_ShouldThrowBudgetPlanNotFoundException()
    {
        // Arrange
        var repository = new BudgetPlan.Persistence.Respositories.BudgetPlanBaseRepository(_context, _currentUserService);
        var invalidId = Guid.NewGuid();
        
        // Act
        await Should.ThrowAsync<BudgetPlanNotFoundException>(repository.GetById(invalidId));
    }

    [Fact]
    public async Task
        GetByIdWithBudgetPlanDetailsList_GetBudgetPlanBase_ShouldReturnBudgetPlaneBaseWithWithBudgetPlanDetailsList()
    {
        // Arrange
        var repository = new BudgetPlan.Persistence.Respositories.BudgetPlanBaseRepository(_context, _currentUserService);
        var validId = BudgetPlanDbContextSeedData.BUDGET_PLAN_BASE_1_GUID;
        
        // Act
        var result = await repository.GetById(validId);
        
        // Assert
        result.ShouldNotBeNull();
        result.Id.ShouldBe(validId);
        result.StatusId.ShouldBe(1);
        result.BudgetPlanDetailsList.ShouldNotBeNull();
        result.BudgetPlanDetailsList.Count.ShouldBeGreaterThan(0);
    }
    
    [Fact]
    public async Task GetByIdWithBudgetPlanDetailsList_GetBudgetPlanBase_GivenInvalidId_ShouldThrowBudgetPlanNotFoundException()
    {
        // Arrange
        var repository = new BudgetPlan.Persistence.Respositories.BudgetPlanBaseRepository(_context, _currentUserService);
        var invalidId = Guid.NewGuid();
        
        // Act
        await Should.ThrowAsync<BudgetPlanNotFoundException>(repository.GetById(invalidId));
    }
}