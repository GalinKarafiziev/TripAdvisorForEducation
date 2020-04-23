#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["TripAdvisorForEducation.Web/TripAdvisorForEducation.Web.csproj", "TripAdvisorForEducation.Web/"]
COPY ["TripAdvisorForEducation.Data/TripAdvisorForEducation.Data.csproj", "TripAdvisorForEducation.Data/"]
COPY ["TripAdvisorForEducation.Data.Models/TripAdvisorForEducation.Data.Models.csproj", "TripAdvisorForEducation.Data.Models/"]
COPY ["TripAdvisorForEducation.Services/TripAdvisorForEducation.Services.csproj", "TripAdvisorForEducation.Services/"]
COPY ["TripAdvisorForEducation.Data.ViewModels/TripAdvisorForEducation.Data.ViewModels.csproj", "TripAdvisorForEducation.Data.ViewModels/"]
RUN dotnet restore "TripAdvisorForEducation.Web/TripAdvisorForEducation.Web.csproj"
COPY . .
WORKDIR "/src/TripAdvisorForEducation.Web"
RUN dotnet build "TripAdvisorForEducation.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TripAdvisorForEducation.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TripAdvisorForEducation.Web.dll"]