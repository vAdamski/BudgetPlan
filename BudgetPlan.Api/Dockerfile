FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["BudgetPlan.Api/BudgetPlan.Api.csproj", "BudgetPlan.Api/"]
COPY ["BudgetPlan.Application/BudgetPlan.Application.csproj", "BudgetPlan.Application/"]
COPY ["BudgetPlan.Domain/BudgetPlan.Domain.csproj", "BudgetPlan.Domain/"]
COPY ["BudgetPlan.Shared/BudgetPlan.Shared.csproj", "BudgetPlan.Shared/"]
COPY ["BudgetPlan.Infrastructure/BudgetPlan.Infrastructure.csproj", "BudgetPlan.Infrastructure/"]
COPY ["BudgetPlan.Persistence/BudgetPlan.Persistence.csproj", "BudgetPlan.Persistence/"]
RUN dotnet restore "BudgetPlan.Api/BudgetPlan.Api.csproj"
COPY . .
WORKDIR "/src/BudgetPlan.Api"
RUN dotnet build "BudgetPlan.Api.csproj" -c Release -o /app/build
RUN dotnet publish "BudgetPlan.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 as base
WORKDIR /app
EXPOSE 80
EXPOSE 443
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "BudgetPlan.Api.dll"]
