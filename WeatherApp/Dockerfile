## docker build -f Dockerfile ..\.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS="http://+:5000"
RUN addgroup -S appgroup -g 10000 && adduser -S appuser -G appgroup -u 10000

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["WeatherApp/WeatherApp.csproj", "./WeatherApp/"]
RUN dotnet restore "WeatherApp/WeatherApp.csproj"
COPY . .
WORKDIR "/src/WeatherApp/"
RUN dotnet build "WeatherApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WeatherApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app

COPY --chown=appuser:appuser --from=publish /app/publish .

USER appuser

ENTRYPOINT ["dotnet", "WeatherApp.dll"]
