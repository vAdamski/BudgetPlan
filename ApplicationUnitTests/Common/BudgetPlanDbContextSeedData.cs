using BudgetPlan.Domain.Entities;
using BudgetPlan.Persistence;
using BudgetPlan.Shared.Enums;

namespace ApplicationUnitTests.Common;

public static class BudgetPlanDbContextSeedData
{
    public static void Seed(BudgetPlanDbContext context)
    {
        List<TransactionCategory> transactionCategories = new()
        {
            new TransactionCategory
            {
                Id = 1,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Zarobki",
                TransactionType = TransactionType.Income,
                OverTransactionCategoryId = null
            },
            new TransactionCategory
            {
                Id = 2,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Praca",
                TransactionType = TransactionType.Income,
                OverTransactionCategoryId = 1
            },
            new TransactionCategory
            {
                Id = 77,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Inne przychody",
                TransactionType = TransactionType.Income,
                OverTransactionCategoryId = 1
            },
            new TransactionCategory
            {
                Id = 78,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Internet Weronika",
                TransactionType = TransactionType.Income,
                OverTransactionCategoryId = 1
            },
            new TransactionCategory
            {
                Id = 79,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Dom Weronika",
                TransactionType = TransactionType.Income,
                OverTransactionCategoryId = 1
            },
            new TransactionCategory
            {
                Id = 3,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Jedzenie",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = null
            },
            new TransactionCategory
            {
                Id = 4,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Jedzenie dom",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 3
            },
            new TransactionCategory
            {
                Id = 5,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Jedzenie miasto",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 3
            },
            new TransactionCategory
            {
                Id = 6,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Jedzenie praca",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 3
            },
            new TransactionCategory
            {
                Id = 7,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Alkohol",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 3
            },
            new TransactionCategory
            {
                Id = 8,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Inne",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 3
            },
            new TransactionCategory
            {
                Id = 9,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Mieszkanie/dom",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = null
            },
            new TransactionCategory
            {
                Id = 10,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Czynsz",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 9
            },
            new TransactionCategory
            {
                Id = 11,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Transport",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = null
            },
            new TransactionCategory
            {
                Id = 12,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Paliwo do auta",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 11
            },
            new TransactionCategory
            {
                Id = 13,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Przeglądy i naprawy auta",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 11
            },
            new TransactionCategory
            {
                Id = 14,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Wyposarzenie dodatkowe auta",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 11
            },
            new TransactionCategory
            {
                Id = 15,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Ubezpieczenie auta",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 11
            },
            new TransactionCategory
            {
                Id = 16,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Bilety komunikacji miejskiej",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 11
            },
            new TransactionCategory
            {
                Id = 17,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Taxi",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 11
            },
            new TransactionCategory
            {
                Id = 18,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Telekomunikacja",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = null
            },
            new TransactionCategory
            {
                Id = 19,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Telefon 1",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 18
            },
            new TransactionCategory
            {
                Id = 20,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Internet",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 18
            },
            new TransactionCategory
            {
                Id = 21,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Inne",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 18
            },
            new TransactionCategory
            {
                Id = 22,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Opieka zdrowotna",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = null
            },
            new TransactionCategory
            {
                Id = 23,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Lekarz",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 22
            },
            new TransactionCategory
            {
                Id = 24,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Badania",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 22
            },
            new TransactionCategory
            {
                Id = 25,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Lekarstwa",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 22
            },
            new TransactionCategory
            {
                Id = 26,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Inne",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 22
            },
            new TransactionCategory
            {
                Id = 27,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Ubezpiecznie PZU",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 22
            },
            new TransactionCategory
            {
                Id = 28,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Ubrania",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = null
            },
            new TransactionCategory
            {
                Id = 29,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Ubrania zwykłe",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 28
            },
            new TransactionCategory
            {
                Id = 30,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Ubrania sportowe",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 28
            },
            new TransactionCategory
            {
                Id = 31,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Buty",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 28
            },
            new TransactionCategory
            {
                Id = 32,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Dodatki",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 28
            },
            new TransactionCategory
            {
                Id = 33,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Inne",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 28
            },
            new TransactionCategory
            {
                Id = 34,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Higiena",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = null
            },
            new TransactionCategory
            {
                Id = 35,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Kosemtyki",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 34
            },
            new TransactionCategory
            {
                Id = 36,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Fryzjer",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 34
            },
            new TransactionCategory
            {
                Id = 37,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Inne",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 34
            },
            new TransactionCategory
            {
                Id = 38,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Rozrywka",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = null
            },
            new TransactionCategory
            {
                Id = 39,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Siłownia/Basen",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 38
            },
            new TransactionCategory
            {
                Id = 40,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Kino/Teatr",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 38
            },
            new TransactionCategory
            {
                Id = 41,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Koncerty",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 38
            },
            new TransactionCategory
            {
                Id = 42,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Czasopisma",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 38
            },
            new TransactionCategory
            {
                Id = 43,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Książki",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 38
            },
            new TransactionCategory
            {
                Id = 44,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Hobby",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 38
            },
            new TransactionCategory
            {
                Id = 45,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Hotel / Turystyka",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 38
            },
            new TransactionCategory
            {
                Id = 46,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Inne",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 38
            },
            new TransactionCategory
            {
                Id = 47,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Inne wydatki",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = null
            },
            new TransactionCategory
            {
                Id = 48,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Dobroczynność",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 47
            },
            new TransactionCategory
            {
                Id = 49,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Prezenty",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 47
            },
            new TransactionCategory
            {
                Id = 50,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Sprzęt RTV/AGD",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 47
            },
            new TransactionCategory
            {
                Id = 51,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Oprogramowanie",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 47
            },
            new TransactionCategory
            {
                Id = 52,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Edukacja / Szkolenia",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 47
            },
            new TransactionCategory
            {
                Id = 53,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Usługi inne",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 47
            },
            new TransactionCategory
            {
                Id = 54,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Podatki",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 47
            },
            new TransactionCategory
            {
                Id = 55,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Inne",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 47
            },
            new TransactionCategory
            {
                Id = 56,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Spłaty długów",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = null
            },
            new TransactionCategory
            {
                Id = 57,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Kredyt hipoteczny",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 56
            },
            new TransactionCategory
            {
                Id = 58,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Kredyt konsumpcyjny",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 56
            },
            new TransactionCategory
            {
                Id = 59,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Pozyczka osobista",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 56
            },
            new TransactionCategory
            {
                Id = 60,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Inne",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 56
            },
            new TransactionCategory
            {
                Id = 61,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Bezpieczna karta",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 56
            },
            new TransactionCategory
            {
                Id = 62,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "MacBook Rata",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 56
            },
            new TransactionCategory
            {
                Id = 63,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Budowanie oszczędności",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = null
            },
            new TransactionCategory
            {
                Id = 64,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Fundusz awaryjny",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 63
            },
            new TransactionCategory
            {
                Id = 65,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Fundusz wydatków nieregularnych",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 63
            },
            new TransactionCategory
            {
                Id = 66,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Poduszka finansowa",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 63
            },
            new TransactionCategory
            {
                Id = 67,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Konto emerytalne IKE/IKZE",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 63
            },
            new TransactionCategory
            {
                Id = 68,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Nadpłata długów",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 63
            },
            new TransactionCategory
            {
                Id = 69,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Fundusz: wakacje",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 63
            },
            new TransactionCategory
            {
                Id = 70,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Fundusz: prezenty świąteczne",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 63
            },
            new TransactionCategory
            {
                Id = 71,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Inne",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 63
            },
            new TransactionCategory
            {
                Id = 72,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "INNE 1",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = null
            },
            new TransactionCategory
            {
                Id = 73,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Canal+",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 72
            },
            new TransactionCategory
            {
                Id = 74,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Spotify",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 72
            },
            new TransactionCategory
            {
                Id = 75,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "Azure",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 72
            },
            new TransactionCategory
            {
                Id = 76,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                TransactionCategoryName = "iCloud",
                TransactionType = TransactionType.Expense,
                OverTransactionCategoryId = 72
            },
        };


        context.TransactionCategories.AddRange(transactionCategories);

        context.BudgetPlans.AddRange(new List<global::BudgetPlan.Domain.Entities.BudgetPlan>()
        {
            new BudgetPlan.Domain.Entities.BudgetPlan
            {
                Id = 1,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                DateFrom = new DateTime(2023, 8, 1),
                DateTo = new DateTime(2023, 8, DateTime.DaysInMonth(2023, 8)),
            },
        });

        List<BudgetPlanDetails> budgetPlanDetails = new List<BudgetPlanDetails>();

        var i = 1;
        foreach (var category in transactionCategories.Where(x => x.OverTransactionCategoryId != null))
        {
            budgetPlanDetails.Add(new BudgetPlanDetails
            {
                Id = i++,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 1),
                StatusId = 1,
                BudgetPlanType = BudgetPlanType.Monthly,
                BudgetPlanId = 1,
                TransactionCategoryId = category.Id,
            });
        }
        
        budgetPlanDetails.FirstOrDefault(x => x.TransactionCategoryId == 2).Value = 5496.0f;
        budgetPlanDetails.FirstOrDefault(x => x.TransactionCategoryId == 77).Value = 400f;
        budgetPlanDetails.FirstOrDefault(x => x.TransactionCategoryId == 78).Value = 37.5f;
        budgetPlanDetails.FirstOrDefault(x => x.TransactionCategoryId == 79).Value = 817.5f;
        budgetPlanDetails.FirstOrDefault(x => x.TransactionCategoryId == 4).Value = 600f;
        budgetPlanDetails.FirstOrDefault(x => x.TransactionCategoryId == 8).Value = 975.05f;
        budgetPlanDetails.FirstOrDefault(x => x.TransactionCategoryId == 10).Value = 1635f;
        budgetPlanDetails.FirstOrDefault(x => x.TransactionCategoryId == 12).Value = 300f;
        budgetPlanDetails.FirstOrDefault(x => x.TransactionCategoryId == 13).Value = 300f;
        budgetPlanDetails.FirstOrDefault(x => x.TransactionCategoryId == 19).Value = 25f;
        budgetPlanDetails.FirstOrDefault(x => x.TransactionCategoryId == 20).Value = 75f;
        budgetPlanDetails.FirstOrDefault(x => x.TransactionCategoryId == 27).Value = 31f;
        budgetPlanDetails.FirstOrDefault(x => x.TransactionCategoryId == 39).Value = 129f;
        budgetPlanDetails.FirstOrDefault(x => x.TransactionCategoryId == 52).Value = 500f;
        budgetPlanDetails.FirstOrDefault(x => x.TransactionCategoryId == 62).Value = 544.95f;
        budgetPlanDetails.FirstOrDefault(x => x.TransactionCategoryId == 63).Value = 1500f;
        budgetPlanDetails.FirstOrDefault(x => x.TransactionCategoryId == 73).Value = 116f;
        budgetPlanDetails.FirstOrDefault(x => x.TransactionCategoryId == 74).Value = 10f;
        budgetPlanDetails.FirstOrDefault(x => x.TransactionCategoryId == 76).Value = 5f;


        context.BudgetPlanDetails.AddRange(budgetPlanDetails);

        context.TransactionDetails.AddRange(new List<TransactionDetail>()
        {
            new TransactionDetail
            {
                Id = 1,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 7),
                StatusId = 1,
                Value = 5496.0f,
                Description = "Wypłata",
                TransactionDate = new DateTime(2023, 8, 7),
                TransactionCategoryId = 2,
            },
            new TransactionDetail
            {
                Id = 2,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 8),
                StatusId = 1,
                Value = 200f,
                Description = "Za projekt",
                TransactionDate = new DateTime(2023, 8, 8),
                TransactionCategoryId = 77,
            },
            new TransactionDetail
            {
                Id = 3,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 13),
                StatusId = 1,
                Value = 37.5f,
                Description = "Za internet",
                TransactionDate = new DateTime(2023, 8, 13),
                TransactionCategoryId = 78,
            },
            new TransactionDetail
            {
                Id = 4,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 13),
                StatusId = 1,
                Value = 817.5f,
                Description = "Za czynsz",
                TransactionDate = new DateTime(2023, 8, 13),
                TransactionCategoryId = 79,
            },
            new TransactionDetail
            {
                Id = 5,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 7),
                StatusId = 1,
                Value = 600f,
                Description = "Jedzenie do domu",
                TransactionDate = new DateTime(2023, 8, 7),
                TransactionCategoryId = 4,
            },
            new TransactionDetail
            {
                Id = 6,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 7),
                StatusId = 1,
                Value = 73.87f,
                Description = "Jedzenie",
                TransactionDate = new DateTime(2023, 8, 7),
                TransactionCategoryId = 8,
            },
            new TransactionDetail
            {
                Id = 7,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 8),
                StatusId = 1,
                Value = 80.41f,
                Description = "Jedzenie",
                TransactionDate = new DateTime(2023, 8, 8),
                TransactionCategoryId = 8,
            },
            new TransactionDetail
            {
                Id = 8,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 9),
                StatusId = 1,
                Value = 3.99f,
                Description = "Jedzenie",
                TransactionDate = new DateTime(2023, 8, 9),
                TransactionCategoryId = 8,
            },
            new TransactionDetail
            {
                Id = 9,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 13),
                StatusId = 1,
                Value = 89.84f,
                Description = "Jedzenie",
                TransactionDate = new DateTime(2023, 8, 12),
                TransactionCategoryId = 8,
            },
            new TransactionDetail
            {
                Id = 10,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 13),
                StatusId = 1,
                Value = 7.10f,
                Description = "Jedzenie",
                TransactionDate = new DateTime(2023, 8, 13),
                TransactionCategoryId = 8,
            },
            new TransactionDetail
            {
                Id = 11,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 10),
                StatusId = 1,
                Value = 1635f,
                Description = "Czynsz",
                TransactionDate = new DateTime(2023, 8, 10),
                TransactionCategoryId = 10,
            },
            new TransactionDetail
            {
                Id = 12,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 9),
                StatusId = 1,
                Value = 130.78f,
                Description = "Gaz do auta",
                TransactionDate = new DateTime(2023, 8, 9),
                TransactionCategoryId = 12,
            },
            new TransactionDetail
            {
                Id = 13,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 8),
                StatusId = 1,
                Value = 226f,
                Description = "Wymiana oleju w aucie",
                TransactionDate = new DateTime(2023, 8, 8),
                TransactionCategoryId = 13,
            },
            new TransactionDetail
            {
                Id = 14,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 10),
                StatusId = 1,
                Value = 25f,
                Description = "Telefon",
                TransactionDate = new DateTime(2023, 8, 10),
                TransactionCategoryId = 19,
            },
            new TransactionDetail
            {
                Id = 15,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 10),
                StatusId = 1,
                Value = 75f,
                Description = "Internet",
                TransactionDate = new DateTime(2023, 8, 10),
                TransactionCategoryId = 20,
            },
            new TransactionDetail
            {
                Id = 16,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 10),
                StatusId = 1,
                Value = 129f,
                Description = "Siłownia",
                TransactionDate = new DateTime(2023, 8, 10),
                TransactionCategoryId = 39,
            },
            new TransactionDetail
            {
                Id = 17,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 10),
                StatusId = 1,
                Value = 500,
                Description = "Na studia",
                TransactionDate = new DateTime(2023, 8, 10),
                TransactionCategoryId = 52,
            },
            new TransactionDetail
            {
                Id = 18,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 8),
                StatusId = 1,
                Value = 544.95f,
                Description = "Macbook Rata",
                TransactionDate = new DateTime(2023, 8, 8),
                TransactionCategoryId = 62,
            },
            new TransactionDetail
            {
                Id = 19,
                CreatedBy = "user@user.pl",
                Created = new DateTime(2023, 8, 10),
                StatusId = 1,
                Value = 1500f,
                Description = "Przyszość",
                TransactionDate = new DateTime(2023, 8, 10),
                TransactionCategoryId = 63,
            },
        });


        context.SaveChanges();
    }
}