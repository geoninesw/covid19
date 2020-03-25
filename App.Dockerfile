# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY Covid19/*.csproj ./Covid19/
RUN dotnet restore

# copy everything else and build app
COPY Covid19/. ./Covid19/
WORKDIR /source/Covid19
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./
ENV ASPNETCORE_URLS http://*:5000
ENV ASPNETCORE_ENVIRONMENT "Staging"
ENTRYPOINT ["dotnet", "Covid19.dll"]