#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["gateways/eShopping.ApiGateway/eShopping.ApiGateway.csproj", "gateways/eShopping.ApiGateway/"]
RUN dotnet restore "./gateways/eShopping.ApiGateway/eShopping.ApiGateway.csproj"
COPY . .
WORKDIR "/src/gateways/eShopping.ApiGateway"
RUN dotnet build "./eShopping.ApiGateway.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./eShopping.ApiGateway.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eShopping.ApiGateway.dll"]