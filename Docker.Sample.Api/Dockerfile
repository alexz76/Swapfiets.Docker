# BASE BUILD STAGE
FROM microsoft/dotnet:2.2-sdk-alpine AS base
WORKDIR /app
EXPOSE 80

WORKDIR /src
COPY Docker.Sample.Api.csproj ./
RUN dotnet restore /Docker.Sample.Api.csproj
COPY . .
WORKDIR /src/
RUN dotnet build Docker.Sample.Api.csproj -c Release -o /app

# PUBLISH STAGE
FROM build AS publish
RUN dotnet publish Docker.Sample.Api.csproj -c Release -o /app

# RUNTIME STAGE
FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine AS runtime
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Docker.Sample.Api.dll"]
