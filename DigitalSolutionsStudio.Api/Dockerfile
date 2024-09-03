#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["DigitalSolutionsStudio.Api.csproj", "DigitalSolutionsStudio.Api/"]
RUN dotnet restore "DigitalSolutionsStudio.Api/DigitalSolutionsStudio.Api.csproj"
WORKDIR "/src/DigitalSolutionsStudio.Api"
COPY . .
RUN dotnet build "DigitalSolutionsStudio.Api.csproj" -c Development -o /app/build

FROM build AS publish
RUN dotnet publish "DigitalSolutionsStudio.Api.csproj" -c Development -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DigitalSolutionsStudio.Api.dll"]