FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Development
WORKDIR /src
COPY ["DuendeIdentityServer/DuendeIdentityServer.csproj", "DuendeIdentityServer/"]
RUN dotnet restore "DuendeIdentityServer/DuendeIdentityServer.csproj"
COPY . .
WORKDIR "/src/DuendeIdentityServer"
RUN dotnet build "DuendeIdentityServer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "DuendeIdentityServer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DuendeIdentityServer.dll"]