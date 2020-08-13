FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.3-alpine.3.11 AS build-env
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Copy csproj and restore as distinct layers
COPY ["EasyBar/EasyBar.csproj", "EasyBar/"]
RUN dotnet restore

RUN pwsh -Command Write-Host "EasyBarApi: Gerando uma nova imagem Docker com Alpine"

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "EasyBar.dll"]