FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
RUN apt-get update && apt-get install -y curl && rm -rf /var/lib/apt/lists/*

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["manager/manager.csproj", "manager/"]
RUN dotnet restore "manager/manager.csproj"
COPY . .
WORKDIR "/src/manager"
RUN dotnet build "manager.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "manager.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "manager.dll"]
HEALTHCHECK CMD curl --fail http://localhost:80/healthz || exit