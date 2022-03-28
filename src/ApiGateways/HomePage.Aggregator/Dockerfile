FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./src/ApiGateways/HomePage.Aggregator/HomePage.Aggregator.csproj", "./src/ApiGateways/HomePage.Aggregator/"]
RUN dotnet restore "./src/ApiGateways/HomePage.Aggregator/HomePage.Aggregator.csproj"
COPY . .
WORKDIR "./src/ApiGateways/HomePage.Aggregator"
RUN dotnet build "HomePage.Aggregator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HomePage.Aggregator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HomePage.Aggregator.dll"]
