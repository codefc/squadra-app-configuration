FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["SquadraExperience.Web.csproj", "."]
RUN dotnet restore "SquadraExperience.Web.csproj"
COPY . ./
WORKDIR "/src/."
RUN dotnet build "SquadraExperience.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SquadraExperience.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SquadraExperience.Web.dll"]