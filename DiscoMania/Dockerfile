FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["DiscoMania/DiscoMania.csproj", "DiscoMania/"]
RUN dotnet restore "DiscoMania/DiscoMania.csproj"
COPY . .
WORKDIR "/src/DiscoMania"
RUN dotnet build "DiscoMania.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DiscoMania.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DiscoMania.dll"]