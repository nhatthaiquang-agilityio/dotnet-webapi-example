FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY src/WebApiSample.csproj ./src/
RUN dotnet restore ./src/WebApiSample.csproj

# copy everything else and build app
COPY src/. ./src/
WORKDIR /app/src
RUN dotnet publish WebApiSample.csproj -c Release -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
WORKDIR /app
COPY --from=build /app/src/out ./
ENTRYPOINT ["dotnet", "WebApiSample.dll"]