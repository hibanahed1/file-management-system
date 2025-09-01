# Use .NET 9 SDK for build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy csproj files first for faster restore
COPY ["src/FileManagementSystem.API/FileManagementSystem.API.csproj", "FileManagementSystem.API/"]
COPY ["src/FileManagementSystem.Application/FileManagementSystem.Application.csproj", "FileManagementSystem.Application/"]
COPY ["src/FileManagementSystem.Infrastructure/FileManagementSystem.Infrastructure.csproj", "FileManagementSystem.Infrastructure/"]
COPY ["src/FileManagementSystem.Domain/FileManagementSystem.Domain.csproj", "FileManagementSystem.Domain/"]

WORKDIR /src/FileManagementSystem.API
RUN dotnet restore "FileManagementSystem.API.csproj"

# Copy all files and build
COPY . .
RUN dotnet build "FileManagementSystem.API.csproj" -c Release -o /app/build
RUN dotnet publish "FileManagementSystem.API.csproj" -c Release -o /app/publish

# Use ASP.NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "FileManagementSystem.API.dll"]
