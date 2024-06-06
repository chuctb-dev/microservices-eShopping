#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 9001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["services/basket/eShopping.Basket.Api/eShopping.Basket.Api.csproj", "services/basket/eShopping.Basket.Api/"]
COPY ["services/basket/eShopping.Basket.Application/eShopping.Basket.Application.csproj", "services/basket/eShopping.Basket.Application/"]
COPY ["shared/eShopping.SharedKernel/eShopping.SharedKernel.csproj", "services/shared/eShopping.SharedKernel/"]
COPY ["services/basket/eShopping.Basket.Core/eShopping.Basket.Core.csproj", "services/basket/eShopping.Basket.Core/"]
COPY ["services/basket/eShopping.Basket.Infrastructure/eShopping.Basket.Infrastructure.csproj", "services/basket/eShopping.Basket.Infrastructure/"]
RUN dotnet restore "./services/basket/eShopping.Basket.Api/eShopping.Basket.Api.csproj"
COPY . .
WORKDIR "/src/services/basket/eShopping.Basket.Api"
RUN dotnet build "./eShopping.Basket.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./eShopping.Basket.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eShopping.Basket.Api.dll"]