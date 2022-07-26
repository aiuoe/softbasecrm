#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/SBCRM.Web.Host/SBCRM.Web.Host.csproj", "src/SBCRM.Web.Host/"]
COPY ["src/SBCRM.Web.Core/SBCRM.Web.Core.csproj", "src/SBCRM.Web.Core/"]
COPY ["src/SBCRM.Application/SBCRM.Application.csproj", "src/SBCRM.Application/"]
COPY ["src/SBCRM.Application.Shared/SBCRM.Application.Shared.csproj", "src/SBCRM.Application.Shared/"]
COPY ["src/SBCRM.Core.Shared/SBCRM.Core.Shared.csproj", "src/SBCRM.Core.Shared/"]
COPY ["src/SBCRM.Core/SBCRM.Core.csproj", "src/SBCRM.Core/"]
COPY ["src/SBCRM.EntityFrameworkCore/SBCRM.EntityFrameworkCore.csproj", "src/SBCRM.EntityFrameworkCore/"]
COPY ["src/SBCRM.GraphQL/SBCRM.GraphQL.csproj", "src/SBCRM.GraphQL/"]
RUN dotnet restore "src/SBCRM.Web.Host/SBCRM.Web.Host.csproj"
COPY . .
WORKDIR "/src/src/SBCRM.Web.Host"
RUN dotnet build "SBCRM.Web.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SBCRM.Web.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SBCRM.Web.Host.dll"]
