using System.Xml.Schema;
using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Shared.Dtos;
using BudgetPlan.Shared.Enums;
using BudgetPlan.Shared.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlan.Application.BudgetPlanMonthView.Queries.GetBudgetPlanMonthView;

public class
    GetBudgetPlanMonthViewQueryHandler : IRequestHandler<GetBudgetPlanMonthViewQuery, BudgetPlanDetailsViewModel>
{
    private readonly IBudgetPlanDbContext _ctx;
    private readonly ICurrentUserService _currentUserService;

    public GetBudgetPlanMonthViewQueryHandler(IBudgetPlanDbContext ctx, ICurrentUserService currentUserService)
    {
        _ctx = ctx;
        _currentUserService = currentUserService;
    }

    public async Task<BudgetPlanDetailsViewModel> Handle(GetBudgetPlanMonthViewQuery request,
        CancellationToken cancellationToken)
    {
        var viewModel = new BudgetPlanDetailsViewModel();

        var categories = await _ctx.TransactionCategories
            .Where(x => x.CreatedBy == _currentUserService.Email &&
                        x.StatusId == 1)
            .ToListAsync(cancellationToken);

        var items = await _ctx.TransactionDetails
            .Where(x => x.CreatedBy == _currentUserService.Email &&
                        x.StatusId == 1 &&
                        x.TransactionDate.Month == request.DateTime.Month &&
                        x.TransactionDate.Year == request.DateTime.Year)
            .ToListAsync(cancellationToken);

        var budgetPlanDetails = await _ctx.BudgetPlanDetails
            .Where(x => x.CreatedBy == _currentUserService.Email &&
                        x.StatusId == 1 &&
                        x.DateFrom.Month == request.DateTime.Month &&
                        x.DateFrom.Year == request.DateTime.Year &&
                        x.DateTo.Month == request.DateTime.Month &&
                        x.DateTo.Year == request.DateTime.Year)
            .ToListAsync(cancellationToken);

        var overCategories = categories.Where(x => x.OverTransactionCategoryId == null).ToList();

        overCategories.ForEach(oc =>
        {
            var ocDto = new OverTransactionCategoryWithDetailsDto
            {
                Id = oc.Id,
                TransactionCategoryName = oc.TransactionCategoryName,
                TransactionType = oc.TransactionType
            };

            var ucs = categories.Where(x => x.OverTransactionCategoryId == oc.Id).ToList();

            foreach (var uc in ucs)
            {
                var transactionCategoryWithDetailsDto = new TransactionCategoryWithDetailsDto
                {
                    Id = uc.Id,
                    TransactionCategoryName = uc.TransactionCategoryName
                };

                var itemsForCategory = items
                    .Where(x => x.TransactionCategoryId == uc.Id)
                    .ToList();

                itemsForCategory.ForEach(i =>
                {
                    transactionCategoryWithDetailsDto.TransactionItems.Add(new TransactionItemDto()
                    {
                        Id = i.Id,
                        Description = i.Description,
                        Value = i.Value,
                        TransactionDate = i.TransactionDate
                    });
                });

                var budgetPlanDetail = budgetPlanDetails
                    .FirstOrDefault(x => x.TransactionCategoryId == uc.Id);
                
                transactionCategoryWithDetailsDto.PlanDetailsForMonthDto = new BudgetPlanDetailsForMonthDto()
                {
                    Value = budgetPlanDetail.Value,
                    Description = budgetPlanDetail.Description,
                    BudgetPlanType = budgetPlanDetail.BudgetPlanType
                };

                ocDto.TransactionCategoryDtos.Add(transactionCategoryWithDetailsDto);
            }

            viewModel.OverTransactionCategoryWithDetailsDtos.Add(ocDto);
        });

        return viewModel;
    }
}