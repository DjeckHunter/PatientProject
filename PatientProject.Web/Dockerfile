FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PatientProject.Web/PatientProject.Web.csproj", "PatientProject.Web/"]
COPY ["PatientProject.Core/PatientProject.Core.csproj", "PatientProject.Core/"]
COPY ["PatientProject.Infrastructure/PatientProject.Infrastructure.csproj", "PatientProject.Infrastructure/"]
RUN dotnet restore "./PatientProject.Web/./PatientProject.Web.csproj"
COPY . .
WORKDIR "/src/PatientProject.Web"
RUN dotnet build "./PatientProject.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PatientProject.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PatientProject.Web.dll"]