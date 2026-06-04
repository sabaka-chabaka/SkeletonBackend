FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["SkeletonBackend.API/SkeletonBackend.API.csproj", "SkeletonBackend.API/"]
COPY ["SkeletonBackend.Application/SkeletonBackend.Application.csproj", "SkeletonBackend.Application/"]
COPY ["SkeletonBackend.Domain/SkeletonBackend.Domain.csproj", "SkeletonBackend.Domain/"]
COPY ["SkeletonBackend.Infrastructure/SkeletonBackend.Infrastructure.csproj", "SkeletonBackend.Infrastructure/"]

RUN dotnet restore "SkeletonBackend.API/SkeletonBackend.API.csproj"

COPY . .
WORKDIR "/src/SkeletonBackend.API"
RUN dotnet build "SkeletonBackend.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SkeletonBackend.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SkeletonBackend.API.dll"]
