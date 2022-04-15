FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Restore as distinct layers
COPY LocadoraFilmesApi.Service.sln ./
COPY ./LocadoraFilmesApi.Service.Api/LocadoraFilmesApi.Service.Api.csproj ./LocadoraFilmesApi.Service.Api/
COPY ./LocadoraFilmesApi.Service.Application/LocadoraFilmesApi.Service.Application.csproj ./LocadoraFilmesApi.Service.Application/
COPY ./LocadoraFilmesApi.Service.CrossCutting/LocadoraFilmesApi.Service.CrossCutting.csproj ./LocadoraFilmesApi.Service.CrossCutting/
COPY ./LocadoraFilmesApi.Service.Domain/LocadoraFilmesApi.Service.Domain.csproj ./LocadoraFilmesApi.Service.Domain/
COPY ./LocadoraFilmesApi.Service.Infrastructure/LocadoraFilmesApi.Service.Infrastructure.csproj ./LocadoraFilmesApi.Service.Infrastructure/
COPY ./LocadoraFilmesApi.Service.Tests/LocadoraFilmesApi.Service.Tests.csproj ./LocadoraFilmesApi.Service.Tests/
RUN dotnet restore

# Build and publish a release
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
EXPOSE 80

ENTRYPOINT ["dotnet", "LocadoraFilmesApi.Service.Api.dll"]