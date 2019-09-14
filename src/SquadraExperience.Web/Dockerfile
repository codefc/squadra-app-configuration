FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["SquadraExperience.Web/SquadraExperience.Web.csproj", "SquadraExperience.Web/"]
RUN dotnet restore "SquadraExperience.Web/SquadraExperience.Web.csproj"
COPY . .
WORKDIR "/src/SquadraExperience.Web"
RUN dotnet build "SquadraExperience.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SquadraExperience.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SquadraExperience.Web.dll"]