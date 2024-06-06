#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["services/order/eShopping.Ordering.Api/eShopping.Ordering.Api.csproj", "services/order/eShopping.Ordering.Api/"]
COPY ["services/order/eShopping.Order.Core/eShopping.Ordering.Core.csproj", "services/order/eShopping.Order.Core/"]
COPY ["shared/eShopping.SharedKernel/eShopping.SharedKernel.csproj", "shared/eShopping.SharedKernel/"]
COPY ["services/order/eShopping.Order.Infrastructure/eShopping.Ordering.Infrastructure.csproj", "services/order/eShopping.Order.Infrastructure/"]
COPY ["services/order/eShopping.Ordering.Application/eShopping.Ordering.Application.csproj", "services/order/eShopping.Ordering.Application/"]
COPY ["infrastructure/eShopping.MassTransit/eShopping.MassTransit.csproj", "infrastructure/eShopping.MassTransit/"]
RUN dotnet restore "./services/order/eShopping.Ordering.Api/eShopping.Ordering.Api.csproj"
COPY . .
WORKDIR "/src/services/order/eShopping.Ordering.Api"
RUN dotnet build "./eShopping.Ordering.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./eShopping.Ordering.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eShopping.Ordering.Api.dll"]