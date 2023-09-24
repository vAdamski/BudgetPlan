using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Shared.Dtos;
using BudgetPlan.Shared.Enums;
using BudgetPlan.Shared.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlan.Application.BudgetPlan.Queries.GetBudgetPlanView;

public class GetBudgetPlanViewCommandHandler : IRequestHandler<GetBudgetPlanViewCommand, BudgetPlanViewModel>
{
    private readonly IBudgetPlanDbContext _context;
    private readonly ICurrentUserService _currentUserService;

    public GetBudgetPlanViewCommandHandler(IBudgetPlanDbContext context, ICurrentUserService currentUserService)
    {
        _context = context;
        _currentUserService = currentUserService;
    }

    public async Task<BudgetPlanViewModel> Handle(GetBudgetPlanViewCommand request, CancellationToken cancellationToken)
    {
        var categoriesWithDetails = await _context
            .TransactionCategories
            .Where(x => x.CreatedBy == _currentUserService.Email &&
                        x.StatusId == 1 &&
                        x.OverTransactionCategoryId == null)
            .Include(x => x.SubTransactionCategories)
            .ToListAsync(cancellationToken);

        var budgetPlanBase = await _context
            .BudgetPlanBases
            .Where(x => x.Id == request.BudgetPlanId &&
                        x.CreatedBy == _currentUserService.Email &&
                        x.StatusId == 1)
            .Include(x => x.BudgetPlanDetailsList)
            .FirstOrDefaultAsync(cancellationToken);

        var items = await _context.TransactionDetails
            .Where(x => x.CreatedBy == _currentUserService.Email &&
                        x.StatusId == 1 &&
                        budgetPlanBase.DateFrom <= x.TransactionDate &&
                        x.TransactionDate <= budgetPlanBase.DateTo)
            .ToListAsync(cancellationToken);

        var groupedItems = items.GroupBy(x => x.TransactionDate.Date).OrderBy(x => x.Key).ToList();

        var vm = new BudgetPlanViewModel();

        foreach (var overCategory in categoriesWithDetails)
        {
            var underCategories = new List<BudgetPlanUnderTransactionCategoryDto>();
            foreach (var underCategory in overCategory.SubTransactionCategories)
            {
                var budgetPlanDetails = budgetPlanBase
                    .BudgetPlanDetailsList
                    .FirstOrDefault(x => x.TransactionCategoryId == underCategory.Id);

                var budgetPlanUnderTransactionCategoryDto = new BudgetPlanUnderTransactionCategoryDto
                {
                    UnderCategoryId = underCategory.Id,
                    UnderCategoryName = underCategory.TransactionCategoryName,
                    BudgetPlanDetailsDto = new BudgetPlanDetailsDto
                    {
                        AmountAllocated = budgetPlanDetails.ExpectedAmount
                    }
                };

                int days = (budgetPlanBase.DateTo - budgetPlanBase.DateFrom).Days + 1;
                for (int day = 1; day <= days; day++)
                {
                    var itemsForDay = groupedItems
                        .Where(x => x.Key.Day == day)
                        .SelectMany(x => x)
                        .ToList()
                        .Where(x => x.TransactionCategoryId == underCategory.Id)
                        .ToList();
                    
                    var transactionItemsForDayDto = new TransactionItemsForDayDto { };
                    foreach (var item in itemsForDay)
                    {
                        transactionItemsForDayDto.TransactionItemDtos.Add(new TransactionItemDto
                        {
                            Id = item.Id,
                            Value = item.Value,
                            Description = item.Description,
                            Date = item.TransactionDate
                        });
                    }
                    
                    budgetPlanUnderTransactionCategoryDto
                        .BudgetPlanDetailsDto
                        .TransactionItemsForDaysDtos
                        .Add(transactionItemsForDayDto);
                }

                underCategories.Add(budgetPlanUnderTransactionCategoryDto);
            }

            vm.BudgetPlanOverTransactionCategoryDtos.Add(new BudgetPlanOverTransactionCategoryDto
            {
                OverCategoryName = overCategory.TransactionCategoryName,
                TransactionType = overCategory.TransactionType,
                UnderTransactionCategoryDtos = underCategories
            });
        }


        return vm;
    }
}