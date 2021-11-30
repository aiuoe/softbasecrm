#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/SBCRM.Migrator/SBCRM.Migrator.csproj", "src/SBCRM.Migrator/"]
COPY ["src/SBCRM.EntityFrameworkCore/SBCRM.EntityFrameworkCore.csproj", "src/SBCRM.EntityFrameworkCore/"]
COPY ["src/SBCRM.Core/SBCRM.Core.csproj", "src/SBCRM.Core/"]
COPY ["src/SBCRM.Core.Shared/SBCRM.Core.Shared.csproj", "src/SBCRM.Core.Shared/"]
RUN dotnet restore "src/SBCRM.Migrator/SBCRM.Migrator.csproj"
COPY . .
WORKDIR "/src/src/SBCRM.Migrator"
RUN dotnet build "SBCRM.Migrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SBCRM.Migrator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SBCRM.Migrator.dll", "-s"]
