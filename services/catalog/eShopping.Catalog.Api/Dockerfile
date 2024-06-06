#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 9000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["services/catalog/eShopping.Catalog.Api/eShopping.Catalog.Api.csproj", "services/catalog/eShopping.Catalog.Api/"]
COPY ["services/catalog/eShopping.Catalog.Application/eShopping.Catalog.Application.csproj", "services/catalog/eShopping.Catalog.Application/"]
COPY ["services/catalog/eShopping.Catalog.Core/eShopping.Catalog.Core.csproj", "services/catalog/eShopping.Catalog.Core/"]
COPY ["shared/eShopping.SharedKernel/eShopping.SharedKernel.csproj", "services/shared/eShopping.SharedKernel/"]
COPY ["services/catalog/eShopping.Catalog.Infrastructure/eShopping.Catalog.Infrastructure.csproj", "services/catalog/eShopping.Catalog.Infrastructure/"]
RUN dotnet restore "./services/catalog/eShopping.Catalog.Api/eShopping.Catalog.Api.csproj"
COPY . .
WORKDIR "/src/services/catalog/eShopping.Catalog.Api"
RUN dotnet build "./eShopping.Catalog.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./eShopping.Catalog.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eShopping.Catalog.Api.dll"]