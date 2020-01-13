FROM mcr.microsoft.com/dotnet/core/aspnet:2.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build
WORKDIR /src
COPY ["Learn.Docker.csproj", "./"]
RUN dotnet restore "./Learn.Docker.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Learn.Docker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Learn.Docker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Learn.Docker.dll"]
