FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BattleRoyale/BattleRoyale.csproj", "BattleRoyale/"]
RUN dotnet restore "BattleRoyale/BattleRoyale.csproj"
COPY . .
WORKDIR "/src/BattleRoyale"
RUN dotnet build "BattleRoyale.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BattleRoyale.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BattleRoyale.dll"]
