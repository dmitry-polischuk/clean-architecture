#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Source/CleanArchitecture.WebApi/CleanArchitecture.WebApi.csproj", "Source/CleanArchitecture.WebApi/"]
COPY ["Source/CleanArchitecture.Infrastructure/CleanArchitecture.Infrastructure.csproj", "Source/CleanArchitecture.Infrastructure/"]
COPY ["Source/CleanArchitecture.Domain/CleanArchitecture.Domain.csproj", "Source/CleanArchitecture.Domain/"]
COPY ["Source/CleanArchitecture.Application/CleanArchitecture.Application.csproj", "Source/CleanArchitecture.Application/"]
RUN dotnet restore "Source/CleanArchitecture.WebApi/CleanArchitecture.WebApi.csproj"
COPY . .
WORKDIR "/src/Source/CleanArchitecture.WebApi"
RUN dotnet build "CleanArchitecture.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CleanArchitecture.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CleanArchitecture.WebApi.dll"]