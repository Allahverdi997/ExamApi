# Base .NET image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
EXPOSE 27017  # Mongo port

# SDK stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WebApi/WebApi.csproj", "WebApi/"]
RUN dotnet restore "./WebApi/WebApi.csproj"
COPY . .
WORKDIR "/src/WebApi"
RUN dotnet build "./WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage
FROM ubuntu:22.04 AS final
WORKDIR /app

RUN apt-get update && \
    apt-get install -y gnupg wget && \
    wget -qO - https://www.mongodb.org/static/pgp/server-6.0.asc | apt-key add - && \
    echo "deb [ arch=amd64 ] https://repo.mongodb.org/apt/ubuntu jammy/mongodb-org/6.0 multiverse" | tee /etc/apt/sources.list.d/mongodb-org-6.0.list && \
    apt-get update && \
    apt-get install -y mongodb-org && \
    mkdir -p /data/db /docker-entrypoint-initdb.d

COPY --from=publish /app/publish .

COPY init-mongo.js /docker-entrypoint-initdb.d/

CMD bash -c "mongod --fork --logpath /var/log/mongod.log --bind_ip_all && dotnet WebApi.dll"
