FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["bindings.cron/bindings.cron.csproj", "bindings.cron/"]
RUN dotnet restore "bindings.cron/bindings.cron.csproj"
COPY . .
WORKDIR "/src/bindings.cron"
RUN dotnet build "bindings.cron.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "bindings.cron.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "bindings.cron.dll"]
