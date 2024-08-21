FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DotnetShenanigans/DotnetShenanigans.csproj", "DotnetShenanigans/"]
RUN dotnet restore "DotnetShenanigans/DotnetShenanigans.csproj"
COPY . .
WORKDIR "/src/DotnetShenanigans"
RUN dotnet build "DotnetShenanigans.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "DotnetShenanigans.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DotnetShenanigans.dll"]
